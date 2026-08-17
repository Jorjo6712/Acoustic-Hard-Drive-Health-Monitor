#pragma once

#include <Arduino.h>
#include "Button.h"

Button::Button(byte pin) : _pin(pin) 
{
  pinMode(pin, INPUT_PULLUP);  
}

bool Button::isPressed()
{
  return digitalRead(_pin) == LOW; 
}