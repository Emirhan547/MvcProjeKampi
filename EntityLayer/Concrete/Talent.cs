using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Talent
    {
        [Key]
        public int TalentID { get; set; }
        [StringLength(75)]
        public string TalentName { get; set; }
        public int TalentLevel { get; set; }
    }
}
