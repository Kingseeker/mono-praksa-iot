#include <SPI.h>
#include <Servo.h>
#include <Wire.h>

Servo servo1;
Servo servo2;
byte position = 0;
const int ir_left_pin  = A2; // analog pin 2
const int ir_right_pin = A3; // analog pin 3
const int ir_rear_pin  = A4; // analog pin 4
int motorSpeed = 60;

void setup() {
  Serial.begin(9600);
  if (Serial)
    Serial.println("USB Serial available");
  
  Wire.begin(8);                // join i2c bus with address #8
  Wire.onReceive(ReceiveWireMessage);
  
  servo1.attach(3);
  servo2.attach(4);
}


void loop() {

 if( position == 1 && (int)analogRead(ir_left_pin)<150 && (int)analogRead(ir_right_pin)<150) 
   forward(motorSpeed);    
  
 else if( position == 2 && (int)analogRead(ir_rear_pin)<150)
   backwards(motorSpeed);    
 
 else if ( position == 3 && (int)analogRead(ir_right_pin)<150)
   steerLeft();    
 
 else if ( position == 4 && (int)analogRead(ir_left_pin)<150 )
   steerRight();    
 
 else 
   stopMotor();
  
}



void ReceiveWireMessage(int packetSize) {
  Serial.println("Received packet '");
  for (int i = 0; i < packetSize; i++) {
    position = Wire.read(); // maybe - 48
    Serial.print(position);
  }
}

// ----- Motor navigation functions ----------------
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
// -------------------------------------------------
