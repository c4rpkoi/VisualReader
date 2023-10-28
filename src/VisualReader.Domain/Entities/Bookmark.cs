using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader.Domain.Entities
{
    public class Bookmark : IEntity<Guid>
    {
       
        public Guid Id { get; set; }

        public Guid IdUser { get; set; }
        public Guid IdChapter { get; set; }

        public string PageInformation { get; set; }

        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }

        public Chapter Chapters { get; set; }
        public User Users { get; set; }

    }
}
