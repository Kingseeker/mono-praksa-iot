#include <LoRa.h>
#include <Wire.h>

bool updated = 0;
byte position = 0;

void setup() {
  
  Serial.begin (9600); 

  if(LoRa.begin(868E6))
   Serial.println("Lora available");

  Wire.begin();  
}

void loop() {

  if (updated == 1) {
    Wire.beginTransmission(8);
    Wire.write(position);
    Wire.endTransmission();
    updated = 0;  
  }
  
  if (LoRa.parsePacket() > 0)
    receiveLoRaPacket();
  
}


// ---------- LoRa side --------------------------------

void receiveLoRaPacket() {       
  while (LoRa.available()) {
    position = LoRa.read();   
  }

  updated = 1;
 
  Serial.println("Message: " + String(position));
  Serial.println("RSSI: " + String(LoRa.packetRssi()));
  Serial.println("Snr: " + String(LoRa.packetSnr()));
  Serial.println();
}

//------------------------------------------------------


