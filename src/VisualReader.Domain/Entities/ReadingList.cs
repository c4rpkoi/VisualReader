using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader.Domain.Entities
{
    public class ReadingList : IEntity<Guid>
    {
        public Guid Id{ get; set; }
        public Guid IdUser{get; set;}
        public DateTime CreateUCT{get; set;}
        public DateTime UpdateUCT{get; set;}

        public User Users { get; set; }
        public IEnumerable<ReadingListItem>  readingListItems { get; set; }
    }
}
