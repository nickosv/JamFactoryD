using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactoryD.Model
{
    public class QualityControl
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Employee { get; set; }
        public string Variant { get; set; }
        public string TimeCheck { get; set; }
        public List<QualityActivity> ActivityList { get; set; }

        public QualityControl(string name, string description, string employee, string variant, string timeCheck, List<QualityActivity> activityList)
        {
            activityList = new List<QualityActivity>();
            this.Name = name;
            this.Description = description;
            this.Employee = employee;
            this.Variant = variant;
            this.TimeCheck = timeCheck;
            this.ActivityList = activityList;
        }

        
    }
}
