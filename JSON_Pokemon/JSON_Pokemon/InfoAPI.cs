using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_Pokemon
{
    public class InfoAPI
    {
        public int weight{ get; set; }
        public int height { get; set; }
        public string GetWeightHeight()
        {
            return $"Weight: {weight}\tHeight: {height}";
        }
        public Sprites sprites { get; set; }
    }

    public class Sprites
    {
        public string front_default { get; set; }
        public string back_default { get; set; }
    }
}



