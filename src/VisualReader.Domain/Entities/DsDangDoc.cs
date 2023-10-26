using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader.Domain.Entities
{
    public class DsDangDoc:IEntity<Guid>
    {
    
        public Guid Id
        {
            get; set;
        }
        public Guid IdUser
        {
            get; set;
        }
        public int Summary
        {
            get; set;
        }
        public DateTime CreateUCT
        {
            get; set;
        }
        public DateTime UpdateUCT
        {
            get; set;
        }

        public User Users { get; set; }
        public IEnumerable<DsDaDoc>  DsDaDocs { get; set; }

    }
}
