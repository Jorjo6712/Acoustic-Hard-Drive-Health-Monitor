#pragma once

#include <Arduino.h>

class Light {
  private:
    byte _pin;
    bool _isLit;

  public:
    Light(byte pin);
    void toggleLight();
};