using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;

namespace FakeDataGenerator.Shared
{
    public class Humidity : SensorMeasure
    {

        public Humidity(int sensorId) : base(sensorId)
        {
            Measuring = GenerateMeasuring();
        }

        public Humidity()
        {

        }

        protected override int GenerateMeasuring()
        {
            Random random = new Random();
            return random.Next(HumidityScale.Lowest, HumidityScale.Highest);
        }

    }

    public static class HumidityScale
    {
        public static int Lowest { get; set; } = 15;
        public static int Highest { get; set; } = 85;
    }
}
