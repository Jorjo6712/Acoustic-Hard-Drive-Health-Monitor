#pragma once

#include <Arduino.h>

class Button {
  private:
    byte _pin;

  public:
    Button(byte pin);
    bool isPressed();
};