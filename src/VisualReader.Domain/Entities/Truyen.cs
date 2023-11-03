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
    public class Truyen : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
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

        public IEnumerable<LoaiTruyenCuaTruyen> LoaiTruyenCuaTruyens { get; }
        public IEnumerable<TheLoaiTruyen> TheLoaiTruyens { get; }
        public IEnumerable<TacGiaTruyen> TacGiaTruyens { get; }
        public IEnumerable<ReadingListItem>  readingListItems { get; set; }
        public IEnumerable<Block> Blocks { get; set; }
        public IEnumerable<FavoriteList> FavoriteLists { get; set; }
    }
}
