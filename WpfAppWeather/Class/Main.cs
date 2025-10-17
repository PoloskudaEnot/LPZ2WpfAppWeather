using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWeather.Class
{
    internal class Main
    {
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }

        public string TempCelsius
        {
            get { double rez = Math.Round(Temp - 273.15, 2);
                return $"{rez} C°";}
        }
    }
}
