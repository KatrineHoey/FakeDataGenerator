using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FakeDataGenerator.Shared
{
    public abstract class SensorMeasure
    {
        [Key]
        public Guid SensorMeasureId { get; protected set; }
        public int Measuring { get; set; }
        public DateTime DateCreated { get; protected set; } = DateTime.Now.ToLocalTime();

        [ForeignKey("Sensor")]
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }

        public SensorMeasure(int sensorId)
        {
            SensorId = sensorId;
        }

        public SensorMeasure()
        {

        }


        protected abstract int GenerateMeasuring();
    }
}
