using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RobotControllerXtreme
{
    class JSONDataHolder
    {
        private SensorReading reading;
        public string JSONString;

        public JSONDataHolder()
        {          
        }

        public void JSONSerializeData(string SNR, string RSSI, string speed, string altitude, string latitude, string longitude)
        {
            reading = new SensorReading(SNR, RSSI, speed, altitude, latitude, longitude);
            JSONString = JsonConvert.SerializeObject(reading);
        }



        private class SensorReading
        {
            //string id;
            public string SNR;
            public string RSSI;
            public string speed;
            public string altitude;
            public string latitude;
            public string longitude;          

            public SensorReading(string SNR, string RSSI, string speed, string altitude, string latitude, string longitude)
            {
                this.SNR = SNR;
                this.RSSI = RSSI;
                this.speed = speed;
                this.altitude = altitude;
                this.latitude = latitude;
                this.longitude = longitude;            
            }


            
        }


        


    }
}
