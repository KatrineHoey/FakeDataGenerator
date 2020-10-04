using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FakeDataGenerator.Shared
{
    public class Sensor
    {
        [Key]
        public int SensorId { get; set; }
        public bool IsOn { get; set; } = false;
        public DataTypeEnum DataType { get; set; }
        public string Name { get; set; }
        public string MeasuringUnit { get; set; }
        public ICollection<SensorMeasure> SensorMeasures { get; set; }

        public Sensor(DataTypeEnum dataType, string name, string measuringUnit)
        {
            DataType = dataType;
            Name = name;
            MeasuringUnit = measuringUnit;
        }

        public Sensor()
        {

        }
    }
}
