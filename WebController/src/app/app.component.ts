import { Component, OnInit } from '@angular/core';
import {Paho} from '../../node_modules/ng2-mqtt/mqttws31';
import { BaasicService } from './baasic.service'

@Component({
  selector: 'app',
  styleUrls: [
    './app.component.css'
  ],
  templateUrl: './app.component.html'
})

export class AppComponent implements OnInit{
  client;
  coords=[[45.55,18.7]];
  zoom=11;
  varijabla = false;
  data = { username: 'mmilince', 
           password: 'nCyNWWvT!', 
           options: ['sliding']};

  constructor(private baasicService: BaasicService) {}

  ngOnInit(){
    this.baasicService.connect(this.data);

    this.client = new Paho.MQTT.Client('ws://iot.eclipse.org:80/ws', 'qwerty12345');
    this.onMessage();
    this.onConnectionLost();
    this.client.connect({onSuccess: this.onConnected.bind(this)});
  }

  onConnected() {
    console.log("Connected");
    this.client.subscribe("ArduinoControl");
    this.sendMessage('Hello World');
  }

  sendMessage(message: string) {
    let packet = new Paho.MQTT.Message(message);
    packet.destinationName = "ArduinoControl";
    this.client.send(packet);
  }

  onMessage() {
    this.client.onMessageArrived = (message: Paho.MQTT.Message) => {
      console.log('Message arrived : ' + message.payloadString);
      if(message.payloadString.length>30){
        this.varijabla=true;
        this.baasicService.sendData('SensorReadings', message.payloadString);
        this.getCoords(message.payloadString);
      }
    };
  }

  onConnectionLost() {
    this.client.onConnectionLost = (responseObject: Object) => {
      console.log('Connection lost : ' + JSON.stringify(responseObject));
    };
  }

  direction(value){
    switch(value){
      case 1:
        this.sendMessage("1");
        break;
      case 2:
        this.sendMessage("2");
        break;
      case 3:
        this.sendMessage("3");
        break;
      case 4:
        this.sendMessage("4");
        break;
      case 5:
        this.varijabla=false;
        this.sendMessage("5");
        break;
      default:
        this.sendMessage("0");
    }
  }
  getCoords(message){
    this.zoom=15;
    var indLat=message.search("latitude");
    var subMessage=message.slice(indLat+11, message.length);
    var indNav=subMessage.indexOf('"');
    var lat=subMessage.slice(0, indNav);

    var indLong=message.search("longitude");
    var subMessage2=message.slice(indLong+12, message.length);
    var indNav=subMessage2.indexOf('"');
    var long=subMessage2.slice(0, indNav);

    if(this.coords.length==1 && this.coords[0][0]==45.55 && this.coords[0][1]==18.7)
      this.coords=[];
      
    this.coords.push([Number(lat), Number(long)]);
  }
}
