using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Entities
{
    public abstract class BaseEntity<TPk>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TPk Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
