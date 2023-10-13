using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.Repositories
{
    public interface ITruyenManagerRepository
    {
        public bool Add(TheLoai data);
        public bool Add(TacGia data);
        public bool Add(Chapter data);
        public bool Add(ChapterData data);
        public bool Add(LoaiTruyen data);
        public bool Add(LoaiTruyenCuaTruyen data);
        public bool Add(TacGiaTruyen data);
        public bool Add(TheLoaiTruyen data);
        public bool Add(Truyen data);

        public bool Update(TheLoai data);
        public bool Update(TacGia data);
        public bool Update(Chapter data);
        public bool Update(ChapterData data);
        public bool Update(LoaiTruyen data);
        public bool Update(LoaiTruyenCuaTruyen data);
        public bool Update(TacGiaTruyen data);
        public bool Update(TheLoaiTruyen data);
        public bool Update(Truyen data);

        public bool Remove(TheLoai data);
        public bool Remove(TacGia data);
        public bool Remove(Chapter data);
        public bool Remove(ChapterData data);
        public bool Remove(LoaiTruyen data);
        public bool Remove(LoaiTruyenCuaTruyen data);
        public bool Remove(TacGiaTruyen data);
        public bool Remove(TheLoaiTruyen data);
        public bool Remove(Truyen data);

        public List<Chapter> GetAll(Chapter data);
        public List<ChapterData> GetAll(ChapterData data);
        public List<LoaiTruyen> GetAll(LoaiTruyen data);
        public List<LoaiTruyenCuaTruyen> GetAll(LoaiTruyenCuaTruyen data);
        public List<TacGia> GetAll(TacGia data);
        public List<TacGiaTruyen> GetAll(TacGiaTruyen data);
        public List<TheLoai> GetAll(TheLoai data);
        public List<TheLoaiTruyen> GetAll(TheLoaiTruyen data);
        public List<Truyen> GetAll(Truyen data);

        public Chapter GetAllByID(Chapter data, Guid id);
        public ChapterData GetAllByID(ChapterData data, Guid id);
        public LoaiTruyen GetAllByID(LoaiTruyen data, Guid id);
        public LoaiTruyenCuaTruyen GetAllByID(LoaiTruyenCuaTruyen data, Guid id);
        public TacGia GetAllByID(TacGia data, Guid id);
        public TacGiaTruyen GetAllByID(TacGiaTruyen data, Guid id);
        public TheLoai GetAllByID(TheLoai data, Guid id);
        public TheLoaiTruyen GetAllByID(TheLoaiTruyen data, Guid id);
        public Truyen GetAllByID(Truyen data, Guid id);
    }
}
