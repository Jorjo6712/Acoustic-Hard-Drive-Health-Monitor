#pragma once

#include <WiFiS3.h>
#include <Arduino.h>
#include "WiFiManager.h"

WiFiManager::WiFiManager(const char* ssid, const char* password, String localIp, String gateway, String subnet, String dnsServer = "1.1.1.1") 
  : _ssid(ssid), _password(password) 
{
  if (!_localIp.fromString(localIp)) {
    Serial.println("Invalid static IP!");
  }
  if (!_subnet.fromString(subnet)) {
    Serial.println("Invalid subnet!");
  }
  if (!_gateway.fromString(gateway)) {
    Serial.println("Invalid gateway!");
  }
  if (!_dnsServer.fromString(dnsServer)) {
    Serial.println("Invalid DNS!");
  }
}

void WiFiManager::connect()
{
  delay(10);
  Serial.println("Connecting to WiFi...");

  WiFi.config(_localIp, _dnsServer, _gateway, _subnet);

  WiFi.begin(_ssid, _password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("\nWiFi connected.");
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());
}

void WiFiManager::ensureConnectivity()
{
  if (WiFi.status() != WL_CONNECTED) {
    Serial.println("WiFi lost, reconnecting...");
    connect();
  }
}