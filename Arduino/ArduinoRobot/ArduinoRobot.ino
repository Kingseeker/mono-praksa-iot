#include <SPI.h>
#include <LoRa.h>
#include <Servo.h>
Servo myservo;
Servo myservo2;
byte position;
const int ir_left_pin  = A2; // analog pin 2
const int ir_right_pin = A3; // analog pin 3
const int ir_rear_pin  = A4; // analog pin 4

void setup() {
 Serial.begin(9600);
 while (!Serial);
 Serial.println("LoRa Receiver Callback");
 if (!LoRa.begin(868E6)) {
   Serial.println("Starting LoRa failed!");
   while (1);
 }
//register the receive callback
 LoRa.onReceive(onReceive);
//put the radio into receive mode
 LoRa.receive();
 myservo.attach(3);
 myservo2.attach(4);
 
}
void onReceive(int packetSize) {
// received a packet
 Serial.print("Received packet '");
// read packet
 for (int i = 0; i < packetSize; i++) {
   position = LoRa.read()-48;
   Serial.print(position);
 }
// print RSSI of packet
 Serial.print("' with RSSI ");
 Serial.println(LoRa.packetRssi());
}
void loop() { 
 int motorSpeed = 60;
 
 if(position == 1 && (int)analogRead(ir_left_pin)<150 && (int)analogRead(ir_right_pin)<150){
   forward(motorSpeed);    
 }
 
 else if(position == 2 && (int)analogRead(ir_rear_pin)<150){
   backwards(motorSpeed);    
 }
 else if(position == 3 && (int)analogRead(ir_right_pin)<150){
   steerLeft();    
 }
 else if(position == 4 && (int)analogRead(ir_left_pin)<150){
   steerRight();    
 }
 
 else {
   stopp();
 }
 if((int)analogRead(ir_left_pin)> 150 || (int)analogRead(ir_right_pin)>150){
  if(position == 2 && (int)analogRead(ir_rear_pin)<150){
    backwards(motorSpeed);
    }
   else{
     stopp();
   }
 }
 else if((int)analogRead(ir_rear_pin)>150){
  if(position == 1 && (int)analogRead(ir_left_pin)<150 && (int)analogRead(ir_right_pin)<150){
     forward(motorSpeed);    
   }
   else if(position == 3 && (int)analogRead(ir_right_pin)<150){
     steerLeft();    
   }
   else if(position == 4 && (int)analogRead(ir_left_pin)<150){
     steerRight();    
   }
   else{
     stopp();
   }    
 }
 
 delay(5);
}
void forward(int motorSpeed) {
   myservo.write(motorSpeed);      
   myservo2.write(motorSpeed);
}
void backwards(int motorSpeed) {
   myservo.write(180-motorSpeed);      
   myservo2.write(180-motorSpeed);
}
void steerLeft() {
   myservo.write(70);      
   myservo2.write(40);
}
void steerRight() {
   myservo.write(40);      
   myservo2.write(70);
}
void stopp(){
   myservo.write(90);      
   myservo2.write(90);
}