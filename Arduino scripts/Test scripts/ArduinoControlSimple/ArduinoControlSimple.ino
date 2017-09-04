#include <SPI.h>              
#include <LoRa.h>              

void setup() {

  // Wait until serial connection is established
  Serial.begin(9600);                  
  while (!Serial);

  // Wait until LoRa connection is established
  while(!LoRa.begin(868E6))                                 

  Serial.println("Communication initialization succeeded.");
}

void loop() {
  
  // Check for incoming message from LoRa
  if (LoRa.parsePacket() > 0)
    receiveLoRaPacket();

  // Check for incoming message from serial (PC)
  if (Serial.available() > 0) 
    receiveSerialPacket();
}

void receiveSerialPacket() {
  byte command = Serial.read(); 
  LoRa.beginPacket();                   
  LoRa.write(command);                 
  LoRa.endPacket();                     
  Serial.println(command);
}

void receiveLoRaPacket() {
  String incoming = "";

  while (LoRa.available()) {
    incoming += (char)LoRa.read();
  }

  Serial.print(incoming);
  Serial.println("RSSI: " + String(LoRa.packetRssi()));
  Serial.println("SNR: " + String(LoRa.packetSnr()));
  Serial.println();
}

