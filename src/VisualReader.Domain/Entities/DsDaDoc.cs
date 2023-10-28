using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader.Domain.Entities
{
    public class DsDaDoc : IEntity<Guid>
    {
      
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdTruyen { get; set; }
        public Guid IdDsDangDoc { get; set; }
        public int Chapter { get; set; }

        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }

        public DsDangDoc DsDangDocs { get; set; }
        public Truyen Truyens { get; set; }

    }
}