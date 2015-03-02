using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model
{
    class Rating
    {
        public string TestPerson { get; set; }
        public string Comment { get; set;}
        public int Rating { get; set; }
        public Rating(string testperson, string comment, int rating) {
            this.TestPerson = testperson;
            this.Comment = comment;
            this.Rating = rating;
        }

    }
}
