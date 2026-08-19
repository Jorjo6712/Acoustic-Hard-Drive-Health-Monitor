#pragma once

#include <Arduino.h>

enum class HttpRequestType {
  GET,
  POST,
  PUT,
  DELETE
};