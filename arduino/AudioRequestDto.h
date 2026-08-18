#pragma once

#include <Arduino.h>
#include "AbstractDto.h"
#include "UUID.h"

class AudioRequestDto : public AbstractDto {
  public:
    UUID recordingId;
    byte[256] audioChunk;
    unsigned long recordedAt;
    int sequenceNumber;

    AudioRequestDto(UUID id, byte* audioChunk, unsigned long recordedAt, int sequenceNumber) 
      : recordingId(recordingId), audioChunk(audioChunk), recordedAt(recordedAt), sequenceNumber(sequenceNumber) 
      {
        memcpy(audioChunk, chunk, 256);
      }

    const char* toJson() override {
      static String json;
      json = "{";

      json += "\"recordingId\":\"" + recordingId.toString() + "\",";
      json += "\"recordedAt\":" + String(recordedAt) + ",";
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
}