﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader.Domain.Entities
{
    [Table("TacGia")]
    public class TacGia
    {
        [Key]
        public Guid ID { get; set; }
        public string Ma { get; set; }
        public string TenTacGia { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public List<TacGiaTruyen> TacGiaTruyens { get; }
    }
}
