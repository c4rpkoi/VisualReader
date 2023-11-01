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
    public class ChapterDataRequest: IRequest<ChapterDataDto>
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
        private static Func<ChapterDataRequest, ChapterData> Converter = Projection.Compile();

        public static Expression<Func<ChapterDataRequest, ChapterData>> Projection
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

        public static ChapterData Create(ChapterDataRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
