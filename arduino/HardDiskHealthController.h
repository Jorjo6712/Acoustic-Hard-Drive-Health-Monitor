#pragma once

#include "UUID.h"
#include "Light.h"
#include "Button.h"
#include <Arduino.h>
#include "Microphone.h"
#include "HttpService.h"
#include "AudioRequestDto.h"

class HardDiskHealthController {
  private:
    Light _light;
    Button _button;
    Microphone _microphone;
    HttpService _httpService;

    bool _isRecording;
    UUID _recordingId;
    int _sequenceNumber = 0;

    void record();
    void sendRequest(byte* audio, int sequenceNumber);

  public:
    HardDiskHealthController(Light light, Microphone microphone, Button button, HttpService httpService);
    void main();
};