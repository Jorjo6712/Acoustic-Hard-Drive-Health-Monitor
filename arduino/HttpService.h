#pragma once

#include <WiFiS3.h>
#include <WiFiSSLClient.h>
#include "HttpRequestType.h"

class HttpService {
  private:
    const char* _hostname;
    WiFiSSLClient& _client;
    uint16_t _port;

  public:
    HttpService(const char* hostname, WiFiSSLClient& client, uint16_t port = 443);

    void sendRequest(
      const char* urlPath,
      const char* body,
      HttpRequestType type
    );
};