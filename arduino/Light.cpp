#pragma once

#include <Arduino.h>
#include "Light.h"

Light::Light(byte pin) : _pin(pin) 
{
  pinMode(pin, OUTPUT);  
}

void Light::toggleLight()
{
  if(_isLit)
  {
    digitalWrite(_pin, LOW);
  } else {
    digitalWrite(_pin, HIGH);
  }

  _isLit = !_isLit;
}