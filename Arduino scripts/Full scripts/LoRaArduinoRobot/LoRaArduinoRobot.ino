#include <AltSoftSerial.h>
#include <LoRa.h>
#include <Wire.h>
#include "TinyGPS++.h"

AltSoftSerial SerialGPS;
TinyGPSPlus WrapperGPS;

bool updated = 0;
byte position = 0;
int rssi;
int snr;

unsigned long lastSendTime;

void setup() {
  
  Serial.begin (9600);

  if(LoRa.begin(868E6))
   Serial.println("Lora available");

  Wire.begin();  
  SerialGPS.begin(9600);   
  lastSendTime = millis();
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
  
   
  if (millis() > lastSendTime + 1000) {

    while(SerialGPS.available()) {
      //Serial.println(WrapperGPS.sentencesWithFix());
      WrapperGPS.encode(SerialGPS.read());
      if(WrapperGPS.location.isUpdated()) {
        Serial.println("Satellite Count:");
        Serial.println(WrapperGPS.satellites.value());
        Serial.println("Latitude:");
        Serial.println(WrapperGPS.location.lat(), 6);
        Serial.println("Longitude:");
        Serial.println(WrapperGPS.location.lng(), 6);
        Serial.println("Speed KMPH:");
        Serial.println(WrapperGPS.speed.kmph());
        Serial.println("Altitude meters:");
        Serial.println(WrapperGPS.altitude.meters());
        Serial.println("");
        
        String message =  String ("{") + 
                          String ("\"SNR\":") + String ("\"") + String(snr) + String("\",") + 
                          String("\"RSSI\":") + String("\"") + String(rssi) + String("\",") +
                          String("\"speed\":") + String("\"") + String(WrapperGPS.speed.kmph()) + String("\",") + 
                          String("\"altitude\":") + String("\"") + String(WrapperGPS.altitude.meters()) + String("\",") +
                          String("\"latitude\":") + String("\"") + String(WrapperGPS.location.lat()) + String("\",") + 
                          String("\"longitude\":") + String("\"") + String(WrapperGPS.location.lng()) + String("\"") +                            
                          String("}");   
        sendMessage(message);      
        break;     
      }
      
    }
    lastSendTime = millis();
  }
}


// ---------- LoRa side --------------------------------

void sendMessage(String outgoing) {
  LoRa.beginPacket();                   // start packet
  LoRa.print(outgoing);                 // add payload
  LoRa.endPacket();                     // finish packet and send it
}

void receiveLoRaPacket() {       
  while (LoRa.available()) {
    position = LoRa.read();
  }

  updated = 1;
  rssi = LoRa.packetRssi();
  snr = LoRa.packetSnr();
 
  Serial.println("Message: " + String(position));
  Serial.println("RSSI: " + String(LoRa.packetRssi()));
  Serial.println("Snr: " + String(LoRa.packetSnr()));
  Serial.println();
}

//------------------------------------------------------


