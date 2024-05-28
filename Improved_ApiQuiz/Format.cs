﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Improved_ApiQuiz
{
    internal class Format
    {
        public int id { get; set; }

        public string? question { get; set; }

        public string? description { get; set; }

        public string? explanation { get; set; }

        public string? category { get; set; }

        public Dictionary<string, string>? answers { get; set; }

        public Dictionary<string, string>? correct_answers { get; set; }
    }
}
