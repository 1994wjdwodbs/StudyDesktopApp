using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSensorMonApp
{
    class SensorData
    {
        public DateTime Current { get; set; } // 현재 시간
        public int Value { get; set; } // 센서값
        public bool SimulFlag { get; set; } // 실제 사용 유무

        public SensorData(DateTime current, int value, bool simulFlag)
        {
            Current = current;
            Value = value;
            SimulFlag = simulFlag;
        }
    }
}
