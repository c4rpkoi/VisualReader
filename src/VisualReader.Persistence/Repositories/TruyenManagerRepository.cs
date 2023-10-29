using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Repositories;
using VisualReader.Domain.Entities;
using VisualReader.Persistence.Context;

namespace VisualReader.Persistence.Repositories
{
    public class TruyenManagerRepository : ITruyenManagerRepository
    {
        private readonly VisualReaderDbContext _context;
        public TruyenManagerRepository(VisualReaderDbContext context)
        {
            _context = context;
        }

        #region Them

        public bool Add(TheLoai data)
        {
            if (data == null) return false;
            else
            {
                var theLoai = _context.TheLoais.ToList().FirstOrDefault(c => c.Ma == data.Ma);
                if (theLoai != null) return false;
                else
                {
                    data.ID = Guid.NewGuid();
                    _context.Add(data);
                    _context.SaveChanges();
                    return true;
                }
            }
        }
        public bool Add(TacGia data)
        {
            if (data == null) return false;
            else
            {
                var tacGia = _context.TacGias.ToList().FirstOrDefault(c => c.Ma == data.Ma);
                if (tacGia != null) return false;
                else
                {
                    data.ID = Guid.NewGuid();
                    _context.Add(data);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Add(Chapter data)
        {
            if (data == null) return false;
            else
            {
                var chapter = _context.Chapters.ToList().FirstOrDefault(c => c.Ma == data.Ma);
                if (chapter != null) return false;
                else
                {
                    data.Id = Guid.NewGuid();
                    _context.Add(data);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Add(ChapterData data)
        {
            if (data == null) return false;
            else
            {
                var chapterData = _context.ChapterDatas.ToList().FirstOrDefault(c => c.Ma == data.Ma);
                if (chapterData != null) return false;
                else
                {
                    data.ID = Guid.NewGuid();
                    _context.Add(data);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Add(LoaiTruyen data)
        {
            if (data == null) return false;
            else
            {
                var loaiTruyen = _context.LoaiTruyens.ToList().FirstOrDefault(c => c.Ma == data.Ma);
                if (loaiTruyen != null) return false;
                else
                {
                    data.ID = Guid.NewGuid();
                    _context.Add(data);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Add(LoaiTruyenCuaTruyen data)
        {
            if (data == null) return false;
            else
            {
                var loaiTruyenCuaTruyen = _context.LoaiTruyenCuaTruyen.ToList().FirstOrDefault(c => c.LoaiTruyenID == data.LoaiTruyenID && c.TruyenID == data.TruyenID);

                if (loaiTruyenCuaTruyen != null) return false;
                else
                {
                    data.ID = Guid.NewGuid();
                    _context.Add(data);
                    _context.SaveChanges();
                    return true;
                }
            }
        }
        public bool Add(TacGiaTruyen data)
        {
            if (data == null) return false;
            else
            {
                var tacGiaTruyen = _context.TacGiaTruyens.ToList().FirstOrDefault(c => c.TacGiaID == data.TacGiaID && c.TruyenID == data.TruyenID);
                if (tacGiaTruyen != null) return false;
                else
                {
                    data.ID = Guid.NewGuid();
                    _context.Add(data);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Add(TheLoaiTruyen data)
        {
            if (data == null) return false;
            else
            {
                var theLoaiTruyen = _context.TheLoaiTruyens.ToList().FirstOrDefault(c => c.TheLoaiID == data.TheLoaiID && c.TruyenID == data.TruyenID);
                if (theLoaiTruyen != null) return false;
                else
                {
                    data.ID = Guid.NewGuid();
                    _context.Add(data);
                    _context.SaveChanges();
                    return true;
                }
            }
        }
        public bool Add(Truyen data)
        {
            if (data == null) return false;
            else
            {
                var truyen = _context.Truyens.ToList().FirstOrDefault(c => c.Ma == data.Ma);
                if (truyen != null) return false;
                else
                {
                    data.ID = Guid.NewGuid();
                    _context.Add(data);
                    _context.SaveChanges();
                    return true;
                }
            }
        }

        #endregion

        #region Sua
        public bool Update(TheLoai data)
        {
            if (data == null) return false;
            else
            {
                var dataTheLoai = _context.TheLoais.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (dataTheLoai == null) return false;
                else
                {
                    dataTheLoai.Ma = data.Ma;
                    dataTheLoai.TenTheLoai = data.TenTheLoai;
                    dataTheLoai.Mota = data.Mota;
                    dataTheLoai.UpdatedUtc = data.UpdatedUtc;
                    _context.Update(dataTheLoai);
                    _context.SaveChanges();
                    return true;
                }
            }
        }
        public bool Update(TacGia data)
        {
            if (data == null) return false;
            else
            {
                var dataTacGia = _context.TacGias.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (dataTacGia == null) return false;
                else
                {
                    dataTacGia.Ma = data.Ma;
                    dataTacGia.TenTacGia = data.TenTacGia;
                    dataTacGia.UpdatedUtc = data.UpdatedUtc;
                    _context.Update(data);
                    _context.SaveChanges();
                    return true;
                }
            }
        }
        public bool Update(Chapter data)
        {
            if (data == null) return false;
            else
            {
                var chapter = _context.Chapters.ToList().FirstOrDefault(c => c.Id == data.Id);
                if (chapter == null) return false;
                else
                {
                    chapter.TruyenID = data.TruyenID;
                    chapter.UserID = data.UserID;
                    chapter.LoaiTruyenCuaTruyenID = data.LoaiTruyenCuaTruyenID;
                    chapter.Title = data.Title;
                    chapter.Ma = data.Ma;
                    chapter.NgayDang = data.NgayDang;
                    chapter.LuotXem = data.LuotXem;
                    chapter.UpdatedUtc = data.UpdatedUtc;
                    _context.Update(chapter);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Update(ChapterData data)
        {
            if (data == null) return false;
            else
            {
                var chapterData = _context.ChapterDatas.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (chapterData == null) return false;
                else
                {
                    chapterData.Ma = data.Ma;
                    chapterData.STT = data.STT;
                    chapterData.ChapterID = data.ChapterID;
                    chapterData.Data = data.Data;
                    chapterData.DataType = data.DataType;
                    chapterData.UpdatedUtc = data.UpdatedUtc;
                    _context.Update(chapterData);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Update(LoaiTruyen data)
        {
            if (data == null) return false;
            else
            {
                var loaiTruyen = _context.LoaiTruyens.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (loaiTruyen == null) return false;
                else
                {
                    loaiTruyen.Ma = data.Ma;
                    loaiTruyen.TenTheLoai = data.TenTheLoai;
                    loaiTruyen.Mota = data.Mota;
                    loaiTruyen.UpdatedUtc = data.UpdatedUtc;
                    _context.Update(loaiTruyen);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Update(LoaiTruyenCuaTruyen data)
        {
            if (data == null) return false;
            else
            {
                var loaiTruyenCuaTruyen = _context.LoaiTruyenCuaTruyen.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (loaiTruyenCuaTruyen == null) return false;
                else
                {
                    loaiTruyenCuaTruyen.LoaiTruyenID = data.LoaiTruyenID;
                    loaiTruyenCuaTruyen.TruyenID = data.TruyenID;
                    loaiTruyenCuaTruyen.UpdatedUtc = data.UpdatedUtc;
                    _context.Update(loaiTruyenCuaTruyen);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Update(TacGiaTruyen data)
        {
            if (data == null) return false;
            else
            {
                var tacGiaTruyen = _context.TacGiaTruyens.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (tacGiaTruyen == null) return false;
                else
                {
                    tacGiaTruyen.TacGiaID = data.TacGiaID;
                    tacGiaTruyen.TruyenID = data.TruyenID;
                    tacGiaTruyen.UpdatedUtc = data.UpdatedUtc;
                    _context.Update(tacGiaTruyen);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Update(TheLoaiTruyen data)
        {
            if (data == null) return false;
            else
            {
                var theLoaiTruyen = _context.TheLoaiTruyens.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (theLoaiTruyen == null) return false;
                else
                {
                    theLoaiTruyen.TruyenID = data.TruyenID;
                    theLoaiTruyen.TheLoaiID = data.TheLoaiID;
                    theLoaiTruyen.UpdatedUtc = data.UpdatedUtc;
                    _context.Update(theLoaiTruyen);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Update(Truyen data)
        {
            if (data == null) return false;
            else
            {
                var truyen = _context.Truyens.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (truyen == null) return false;
                else
                {
                    truyen.Ma = data.Ma;
                    truyen.TenTruyen = data.TenTruyen;
                    truyen.AnhBia = data.AnhBia;
                    truyen.AgeRatting = data.AgeRatting;
                    truyen.TinhTrang = data.TinhTrang;
                    truyen.LuotXem = data.LuotXem;
                    truyen.LuotDanhGia = data.LuotDanhGia;
                    truyen.SoLuongTheoDoi = data.SoLuongTheoDoi;
                    truyen.XepHang = data.XepHang;
                    truyen.NoiDung = data.NoiDung;
                    truyen.TrangThai = data.TrangThai;
                    truyen.UpdatedUtc = data.UpdatedUtc;
                    _context.Update(truyen);
                    _context.SaveChanges();
                    return true;
                }

            }
        }

        #endregion

        #region Xoa
        public bool Remove(Chapter data)
        {
            if (data == null) return false;
            else
            {
                var chapter = _context.Chapters.ToList().FirstOrDefault(c => c.Id == data.Id);
                if (chapter == null) return false;
                else
                {
                    _context.Remove(chapter);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Remove(ChapterData data)
        {
            if (data == null) return false;
            else
            {
                var chapterData = _context.ChapterDatas.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (chapterData == null) return false;
                else
                {
                    _context.Remove(chapterData);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Remove(LoaiTruyen data)
        {
            if (data == null) return false;
            else
            {
                var loaiTruyen = _context.LoaiTruyens.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (loaiTruyen == null) return false;
                else
                {
                    _context.Remove(loaiTruyen);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Remove(LoaiTruyenCuaTruyen data)
        {
            if (data == null) return false;
            else
            {
                var loaiTruyenCuaTruyen = _context.LoaiTruyenCuaTruyen.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (loaiTruyenCuaTruyen == null) return false;
                else
                {
                    _context.Remove(loaiTruyenCuaTruyen);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Remove(TacGia data)
        {
            if (data == null) return false;
            else
            {
                var tacGia = _context.TacGias.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (tacGia == null) return false;
                else
                {
                    _context.Remove(tacGia);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Remove(TacGiaTruyen data)
        {
            if (data == null) return false;
            else
            {
                var sacGiaTruyen = _context.TacGiaTruyens.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (sacGiaTruyen == null) return false;
                else
                {
                    _context.Remove(sacGiaTruyen);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Remove(TheLoai data)
        {
            if (data == null) return false;
            else
            {
                var theLoai = _context.TheLoais.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (theLoai == null) return false;
                else
                {
                    _context.Remove(theLoai);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Remove(TheLoaiTruyen data)
        {
            if (data == null) return false;
            else
            {
                var theLoaiTruyen = _context.TheLoaiTruyens.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (theLoaiTruyen == null) return false;
                else
                {
                    _context.Remove(theLoaiTruyen);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        public bool Remove(Truyen data)
        {
            if (data == null) return false;
            else
            {
                var truyen = _context.Truyens.ToList().FirstOrDefault(c => c.ID == data.ID);
                if (truyen == null) return false;
                else
                {
                    _context.Remove(truyen);
                    _context.SaveChanges();
                    return true;
                }

            }
        }
        #endregion

        #region Lay List
        public List<Chapter> GetAll(Chapter data)
        {
            return _context.Chapters.ToList();
        }
        public List<ChapterData> GetAll(ChapterData data)
        {
            return _context.ChapterDatas.ToList();
        }
        public List<LoaiTruyen> GetAll(LoaiTruyen data)
        {
            return _context.LoaiTruyens.ToList();
        }
        public List<LoaiTruyenCuaTruyen> GetAll(LoaiTruyenCuaTruyen data)
        {
            return _context.LoaiTruyenCuaTruyen.ToList();
        }
        public List<TacGia> GetAll(TacGia data)
        {
            return _context.TacGias.ToList();
        }
        public List<TacGiaTruyen> GetAll(TacGiaTruyen data)
        {
            return _context.TacGiaTruyens.ToList();
        }
        public List<TheLoai> GetAll(TheLoai data)
        {
            return _context.TheLoais.ToList();
        }
        public List<TheLoaiTruyen> GetAll(TheLoaiTruyen data)
        {
            return _context.TheLoaiTruyens.ToList();
        }
        public List<Truyen> GetAll(Truyen data)
        {
            return _context.Truyens.ToList();
        }
        #endregion

        #region Lay list theo ID
        public Chapter GetAllByID(Chapter data, Guid id)
        {
            return _context.Chapters.ToList().FirstOrDefault(c => c.Id == id);
        }
        public ChapterData GetAllByID(ChapterData data, Guid id)
        {
            return _context.ChapterDatas.ToList().FirstOrDefault(c => c.ChapterID == id);
        }
        public LoaiTruyen GetAllByID(LoaiTruyen data, Guid id)
        {
            return _context.LoaiTruyens.ToList().FirstOrDefault(c => c.ID == id);
        }
        public LoaiTruyenCuaTruyen GetAllByID(LoaiTruyenCuaTruyen data, Guid id)
        {
            return _context.LoaiTruyenCuaTruyen.ToList().FirstOrDefault(c => c.ID == id);
        }
        public TacGia GetAllByID(TacGia data, Guid id)
        {
            return _context.TacGias.ToList().FirstOrDefault(c => c.ID == id);
        }
        public TacGiaTruyen GetAllByID(TacGiaTruyen data, Guid id)
        {
            return _context.TacGiaTruyens.ToList().FirstOrDefault(c => c.ID == id);
        }
        public TheLoai GetAllByID(TheLoai data, Guid id)
        {
            return _context.TheLoais.ToList().FirstOrDefault(c => c.ID == id);
        }
        public TheLoaiTruyen GetAllByID(TheLoaiTruyen data, Guid id)
        {
            return _context.TheLoaiTruyens.ToList().FirstOrDefault(c => c.ID == id);
        }
        public Truyen GetAllByID(Truyen data, Guid id)
        {
            return _context.Truyens.ToList().FirstOrDefault(c => c.ID == id);
        }
        #endregion
    }
}
