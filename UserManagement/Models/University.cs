using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_m_universities")]
    public class University
    {
        
        
        [Key]
        public int UniversityId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Education> Education { get; set; }

        //public readonly ILazyLoader _lazyLoader;
        //public University()
        //{

        //}
        //public University(ILazyLoader lazyLoader)
        //{
        //    _lazyLoader = lazyLoader;
        //}
        //private ICollection<Education> _education;

        //public virtual ICollection<Education> Education
        //{
        //    get => _lazyLoader.Load(this, ref _education);
        //    set => _education = value;
        //}
    }
}
