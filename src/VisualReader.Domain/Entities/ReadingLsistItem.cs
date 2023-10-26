using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader.Domain.Entities
{
    public class ReadingLsistItem : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdTruyen { get; set; }
        public Guid IdReadingList { get; set; }
        public Guid IdChapter { get; set; }
        public string ReagingIndex { get; set; }

        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }

        public ReadingList  ReadingLists { get; set; }
        public Truyen Truyens { get; set; }
    }
}
