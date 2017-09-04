#include <SPI.h>
#include <Servo.h>
#include <Wire.h>

Servo servo1;
Servo servo2;
byte position = 0;
int motorSpeed = 60;

void setup() {
  Serial.begin(9600);
  if (Serial)
    Serial.println("USB Serial available");
  
  Wire.begin(8);                // join i2c bus with address #8
  Wire.onReceive(onReceive);
  
  servo1.attach(3);
  servo2.attach(4);
}


// Wire onReceive
void onReceive(int packetSize) {
 Serial.println("Received packet '");
 for (int i = 0; i < packetSize; i++) {
   position = Wire.read() - 48;
   Serial.print(position);
 }
}


void loop() {
 if(position == 1)
   forward(motorSpeed);    
 
 else if(position == 2)
   backwards(motorSpeed);    
 
 else if(position == 3)
   steerLeft();    
 
 else if(position == 4)
   steerRight();    
 
 else 
   stopMotor();
}


void forward(int motorSpeed) {
   servo1.write(motorSpeed);      
   servo2.write(motorSpeed);
}
void backwards(int motorSpeed) {
   servo1.write(180-motorSpeed);      
   servo2.write(180-motorSpeed);
}
void steerLeft() {
   servo1.write(70);      
   servo2.write(40);
}
void steerRight() {
   servo1.write(40);      
   servo2.write(70);
}
void stopMotor(){
   servo1.write(90);      
   servo2.write(90);
}

