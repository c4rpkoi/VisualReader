using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisualReader
{
    [Table("LoaiTruyenCuaTruyen")]
    public class LoaiTruyenCuaTruyen : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        public Guid LoaiTruyenID { get; set; }
        public Guid TruyenID { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public LoaiTruyen LoaiTruyen { get; }
        public Truyen Truyen { get; }
        public IEnumerable<Chapter> Chapters { get; }
    }
}