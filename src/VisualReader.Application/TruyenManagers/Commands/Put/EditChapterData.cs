﻿using MediatR;
using System.Linq.Expressions;

namespace VisualReader
{
    public class EditChapterData : IRequest<ChapterDataDto>
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public int STT { get; set; }
        public Guid ChapterID { get; set; }
        public byte[]? Data { get; set; }
        public int DataType { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public Chapter Chapter { get; }
        private static Func<EditChapterData, ChapterData> Converter = Projection.Compile();

        public static Expression<Func<EditChapterData, ChapterData>> Projection
        {
            get
            {
                return entity => new ChapterData
                {
                    Id = entity.Id,
                    Ma = entity.Ma,
                    STT = entity.STT,
                    ChapterID = entity.ChapterID,
                    Data = entity.Data,
                    DataType = entity.DataType,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                };
            }
        }

        public static ChapterData Edit(EditChapterData model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}