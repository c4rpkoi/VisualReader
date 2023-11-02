using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader.Domain.Entities
{
    public class Chapter:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid TruyenID { get; set; }
        public string UserID { get; set; }
        public Guid LoaiTruyenCuaTruyenID { get; set; }
        public string? Title { get; set; }
        public float Ma { get; set; }
        public DateTime NgayDang { get; set; }
        public int LuotXem { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public ChapterData ChapterData { get; }
        public LoaiTruyenCuaTruyen LoaiTruyenCuaTruyen { get; }
        public IEnumerable<Comment> Comments { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
    }
}
