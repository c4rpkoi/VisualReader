
namespace VisualReader
{
    public class BaiViet : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public DateTime ThoiGianDang { get; set; }
        public string Anh { get; set; }
        public Comment Comment { get; set; }
        public User? User { get; set; }

    }
}
