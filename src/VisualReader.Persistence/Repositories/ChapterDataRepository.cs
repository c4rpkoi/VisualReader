using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Repositories;
using VisualReader.Application.TruyenManagers.Models;
using VisualReader.Domain.Entities;
using VisualReader.Persistence.Context;

namespace VisualReader.Persistence.Repositories
{
    public class ChapterDataRepository : GenericRepository<ChapterData,Guid>,IChapterDataRepository
    {
        private readonly VisualReaderDbContext _context;
        public ChapterDataRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ChapterData> AsQueryable()
        {
            return base.AsQueryable();
        }
        protected override void Update(ChapterData requestObject, ChapterData targetObject)
        {
            targetObject.Ma = requestObject.Ma;
            targetObject.STT = requestObject.STT;
            targetObject.ChapterID = requestObject.ChapterID;
            targetObject.Data = requestObject.Data;
            targetObject.DataType =  requestObject.DataType;
            targetObject.UpdatedUtc = requestObject.UpdatedUtc;
        }
    }
}
