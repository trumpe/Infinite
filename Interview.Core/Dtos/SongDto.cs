using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Core.Dtos
{
    public class SongDto
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public Guid UserID { get; set; }        
        public DateTime Created { get; set; }
    }
}
