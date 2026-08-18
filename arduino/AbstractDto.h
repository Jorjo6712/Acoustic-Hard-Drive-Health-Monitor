#pragma once

#include <Arduino.h>

class AbstractDto {
  public:
    virtual const char* toJson() = 0;
};