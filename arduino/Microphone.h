#pragma once

#include <Arduino.h>

class Microphone {
  private:
    byte _pin;

  public:
    Microphone(byte pin);
    int record();
};