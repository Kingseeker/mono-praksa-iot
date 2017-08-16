const mqtt = require('mqtt')  
const client = mqtt.connect('mqtt://broker.hivemq.com') 

client.on('connect', function () {
  client.subscribe('presence')
  client.publish('presence', 'Hello mqtt')
})

client.on('message', function (topic, message) {
  // message is Buffer
  console.log(message.toString())
  client.end()
})