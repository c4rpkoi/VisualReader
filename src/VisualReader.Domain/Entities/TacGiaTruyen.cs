using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisualReader
{
    [Table("TacGiaTruyen")]
    public class TacGiaTruyen : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        public Guid TacGiaID { get; set; }
        public Guid TruyenID { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public Truyen Truyen { get; }
        public TacGia TacGia { get; }
    }
}