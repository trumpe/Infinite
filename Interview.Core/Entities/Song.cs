using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Core.Entities
{
    public class Song
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public Guid UserID { get; set; }
        public virtual User User { get; set; }
        public DateTime Created { get; set; }
    }
}
