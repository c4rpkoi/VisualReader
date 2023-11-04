using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader.Domain.Entities
{
    public class ReadingListItem : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdTruyen { get; set; }
        public Guid IdDsDangDoc { get; set; }
        public Guid IdChapter { get; set; }
        public string PageIndex { get; set; }
        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }
        public ReadingList  ReadingLists { get; set; }
        public Truyen Truyens { get; set; }
    }
}
