using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfAppWeather.Class
{
    internal class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string icon { get; set; }
        public string Icon
        {
            get { return $"http://openweathermap.org/img/wn/{icon}@2x.png"; }
        }
    }
}
