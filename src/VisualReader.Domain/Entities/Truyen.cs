using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader.Domain.Entities
{
    [Table("Truyen")]
    public class Truyen
    {
        [Key]
        public Guid ID { get; set; }
        public string Ma { get; set; }
        public string TenTruyen { get; set; }
        public byte[] AnhBia { get; set; }
        public int AgeRatting { get; set; }
        public int TinhTrang { get; set; }
        public int LuotXem { get; set; }
        public int LuotDanhGia { get; set; }
        public int SoLuongTheoDoi { get; set; }
        public float XepHang { get; set; }
        public string NoiDung { get; set; }
        public int TrangThai { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }

        public List<LoaiTruyenCuaTruyen> LoaiTruyenCuaTruyens { get; }
        public List<TheLoaiTruyen> TheLoaiTruyens { get; }
        public List<TacGiaTruyen> TacGiaTruyens { get; }
        public IEnumerable<DsDaDoc> DsDaDocs { get; set; }
        public IEnumerable<Block> Blocks { get; set; }
        public IEnumerable<DsQuanTam> DsQuanTams { get; set; }
    }
}
