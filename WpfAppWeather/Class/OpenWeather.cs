﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWeather.Class
{
    internal class OpenWeather
    {
        public Coord coord { get; set; }
        public Weather[] weather { get; set; }

        [JsonProperty("base")]
        public string base1 { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public int Visibility { get; set; }
        public Clouds clouds { get; set; }
        public long dt { get; set; }
        public Sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
