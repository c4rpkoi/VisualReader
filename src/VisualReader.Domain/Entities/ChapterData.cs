using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisualReader
{
    [Table("ChapterData")]
    public class ChapterData : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        public string Ma { get; set; }
        public int STT { get; set; }
        public Guid ChapterID { get; set; }
        public byte[]? Data { get; set; }
        public int DataType { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public Chapter Chapter { get; }
    }
}