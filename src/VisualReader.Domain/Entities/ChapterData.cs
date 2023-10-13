using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader.Domain.Entities
{
    [Table("ChapterData")]
    public class ChapterData
    {
        [Key]
        public Guid ID { get; set; }
        public string Ma { get; set; }
        public Guid ChapterID { get; set; }
        public byte[]? DataImg { get; set; }
        public string? DataText { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public Chapter Chapter { get; }
    }
}
