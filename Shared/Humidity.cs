using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;

namespace FakeDataGenerator.Shared
{
    public class Humidity
    {
        [Key]
        public Guid Id { get; private set; }
        public int Measuring { get; set; }
        public DateTime DateCreated { get; private set; }
        public DataTypeEnum DataType { get; private set; }

        public Humidity()
        {
            Measuring = GenerateMeasuringForHumidity();
            DateCreated = DateTime.Now.ToLocalTime();
            DataType = DataTypeEnum.Humidity;
        }


       
        private int GenerateMeasuringForHumidity()
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
