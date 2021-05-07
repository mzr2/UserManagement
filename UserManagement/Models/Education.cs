using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_m_Educations")]
    public class Education
    {
        public int EducationId { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public int UniversityId { get; set; }
        
        public virtual University University { get; set; }
        [JsonIgnore]
        public virtual ICollection<Profiling> Profiling { get; set; }
    }
}
