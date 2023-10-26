﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.Repositories
{
    public interface IDsQuanTamRepository : IRepository<DsQuanTam, Guid>
    {
        IQueryable<DsQuanTam> AsQueryable();
        public bool AddDsQuanTam(DsQuanTam  dsQuanTam);
        public bool DeleteDsQuanTam(Guid id);

    }
}
