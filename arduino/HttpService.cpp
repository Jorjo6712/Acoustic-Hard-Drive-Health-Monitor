#pragma once

#include "HttpService.h"

HttpService::HttpService(
    const char* hostname,
    WiFiSSLClient client,
    uint16_t port
)
    : _hostname(hostname), _client(client), _port(port)
{
}

void HttpService::sendRequest(
    const char* urlPath,
    const char* body,
    HttpRequestType type
)
{
    // Connect using HTTPS
    if (!_client.connect(_hostname, _port)) {
        Serial.println("HTTPS connection failed");
        return;
    }

    // Select HTTP method
    const char* method =
        (type == HttpRequestType::GET)  ? "GET" :
        (type == HttpRequestType::POST) ? "POST" :
        (type == HttpRequestType::PUT)  ? "PUT" :
                                          "DELETE";

    // Request line
    _client.print(method);
    _client.print(" ");
    _client.print(urlPath);
    _client.println(" HTTP/1.1");

    // Headers
    _client.print("Host: ");
    _client.println(_hostname);

    _client.println("User-Agent: UNO-R4");
    _client.println("Connection: close");

    // Optional JSON body
    if (body && strlen(body) > 0) {
        _client.println("Content-Type: application/json");

        _client.print("Content-Length: ");
        _client.println(strlen(body));

        _client.println();

        _client.println(body);
    }
    else {
        _client.println();
    }

    // Read response headers
    while (_client.connected()) {
        String line = _client.readStringUntil('\n');

        if (line == "\r") {
            break;
        }
    }

    // Read response body
    String response = _client.readString();

    Serial.println("Response:");
    Serial.println(response);

    // Close HTTPS connection
    _client.stop();
}