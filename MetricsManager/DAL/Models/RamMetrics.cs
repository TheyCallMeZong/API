﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Models
{
    public class RamMetrics
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTimeOffset Tie { get; set; }
    }
}
