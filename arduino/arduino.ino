#include "HardDiskHealthController.h"
#include "HttpService.h"
#include "WiFiManager.h"
#include "Microphone.h"
#include "Config.h"
#include "Button.h"
#include "Light.h"

WiFiSSLClient _sslClient;

Light _light(RECORD_LIGHT_PIN);
Button _button(RECORD_BUTTON_PIN);
Microphone _microphone(MICROPHONE_PIN);

HttpService _httpService(API_HOSTNAME, _sslClient, 443);
HardDiskHealthController _controller(_light, _microphone, _button, _httpService);
WiFiManager _wiFiManager(WIFI_SSID, WIFI_PASSWORD, WIFI_STATIC_IP, WIFI_GATEWAY, WIFI_SUBNET_MASK, WIFI_DNS_SERVER);

unsigned long _lastWiFiKeepAlive = 0;

void setup() { 
  Serial.begin(9600);
  
  _wiFiManager.connect();
}

void loop() {
  _controller.main();

  if(millis() - _lastWiFiKeepAlive > 5000) {
    _wiFiManager.ensureConnectivity();
    _lastWiFiKeepAlive = millis();
  }
}
