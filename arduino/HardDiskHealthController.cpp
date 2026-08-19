#pragma once

#include <Arduino.h>
#include "HardDiskHealthController.h"

HardDiskHealthController::HardDiskHealthController(Light light, Microphone microphone, Button button, HttpService httpService) : _light(light), _microphone(microphone), _button(button), _httpService(httpService) { }

void HardDiskHealthController::main() {
  if(_button.isPressed())
  {
    _isRecording = !_isRecording;

    if(_isRecording)
    {
      _recordingId.generate();
      _sequenceNumber = 0;
    }

    _light.toggleLight();

    delay(250); // debounce
    return;
  }

  if(_isRecording)
  {
    record();
  }
}

void HardDiskHealthController::record() {
  _sequenceNumber++;
  int audio = _microphone.record();

  byte chunk[256];
  memset(chunk, 0, 256);
  chunk[0] = (byte)audio;

  sendRequest(chunk);
}

void HardDiskHealthController::sendRequest(byte* audio) {
  AudioRequestDto dto(_recordingId, audio, _sequenceNumber);
  const char* requestBody = dto.toJson();

  const char* endpointPath = "/api/record";
  _httpService.sendRequest(endpointPath, requestBody, HttpRequestType::POST);
}