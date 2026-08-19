#pragma once

#include <Arduino.h>
#include "AbstractDto.h"
#include "UUID.h"

class AudioRequestDto : public AbstractDto {
  public:
    UUID recordingId;
    byte audioChunk[256];
    int sequenceNumber;

    AudioRequestDto(UUID id, const byte* audioChunk, int sequenceNumber) 
      : recordingId(recordingId), sequenceNumber(sequenceNumber) 
      {
        memcpy(this->audioChunk, audioChunk, 256);
      }

    const char* toJson() override {
      static String json;
      json = "{";

      json += "\"recordingId\":\"";
      json += recordingId.toCharArray();
      json += "\",";

      json += "\"sequenceNumber\":" + String(sequenceNumber) + ",";

      json += "\"audioChunk\":[";
      for (size_t i = 0; i < 256; i++) {
          json += String(audioChunk[i]);
          if (i < 255) json += ",";
      }
      json += "]";

      json += "}";

      return json.c_str();
    }
};