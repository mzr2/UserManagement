using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_t_roleaccounts")]
    public class RoleAccount
    {
        public string NIK { get; set; }
        public virtual Account Account { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
