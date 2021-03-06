﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactoryD.Model
{
    public class QualityActivity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public DateTime Time { get; set; }
        public string ExpectedResult { get; set; }
        public string ActualResult { get; set; }

        public QualityActivity(string name, string description, string details, DateTime time, string expectedResult, string actualResult)
        {
            this.Name = name;
            this.Description = description;
            this.Details = details;
            this.Time = time;
            this.ExpectedResult = expectedResult;
            this.ActualResult = actualResult;
        }

    }
}
