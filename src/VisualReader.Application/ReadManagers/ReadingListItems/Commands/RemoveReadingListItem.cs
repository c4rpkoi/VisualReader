using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader { 
    public class RemoveReadingListItem : IRequest<bool>
    {
        public Guid Id { get; set; }

        public RemoveReadingListItem(Guid id) => Id = id;

    }
}
