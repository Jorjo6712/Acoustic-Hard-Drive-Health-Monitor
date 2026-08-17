#pragma once

#include <Arduino.h>
#include "Microphone.h"

Microphone::Microphone(byte pin) : _pin(pin) 
{
  pinMode(pin, INPUT);  
}

int Microphone::record()
{
  return analogRead(_pin);
}