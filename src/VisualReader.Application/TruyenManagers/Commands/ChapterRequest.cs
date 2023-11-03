﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Comments.Commands.Models;
using VisualReader.Application.TruyenManagers.Commands.Models;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.TruyenManagers.Commands
{
    public class ChapterRequest : IRequest<ChapterDataDto>
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
        public IEnumerable<Chapter> Chapters { get; set; }
        private static Func<ChapterRequest, Chapter> Converter = Projection.Compile();

        public static Expression<Func<ChapterRequest, Chapter>> Projection
        {
            get
            {
                return entity => new Chapter
                {
                    Id = entity.Id,
                    TruyenID = entity.TruyenID,
                    UserID = entity.UserID,
                    LoaiTruyenCuaTruyenID = entity.LoaiTruyenCuaTruyenID,
                    Title = entity.Title,
                    Ma = entity.Ma,
                    NgayDang = entity.NgayDang,
                    LuotXem = entity.LuotXem,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                };
            }
        }

        public static Chapter Create(ChapterRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}