﻿using System;

namespace MetricsAgent.Data
{
    public class DotNetMetricsDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
    }
}
