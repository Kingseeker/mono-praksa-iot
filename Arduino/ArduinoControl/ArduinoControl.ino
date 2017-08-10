#include <SPI.h>
#include <LoRa.h>

byte command = 0;

void sendPacket() 
{
  // send packet
  LoRa.beginPacket();
  LoRa.write(command);
  LoRa.endPacket();  
  
  //Serial.print("Sending packet: ");
  Serial.println(command);
}


void setup() {

  // start serial
  Serial.begin(9600); 
  while (!Serial) {
     Serial.println("Starting serial failed!"); // wait for serial port to connect. Needed for native USB port only
  };
  
  // start LoRa
  if (!LoRa.begin(868E6)) 
  {
    Serial.println("Starting LoRa failed!");
    while (1);
  }

  Serial.println("Arduino Central Controller with Lora");
}

void loop() {

  //Serial.println("Awaiting command...");
  if (Serial.available() > 0) {
    
    //Serial.println("Command received!");
    
    // get incoming byte:
    command = Serial.read();

    sendPacket();
  }

  //delay(5000);
}





