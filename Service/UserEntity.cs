using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    [Table("tb_user")]
    public class UserEntity
    {
        public long ID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public virtual List<RoleEntity> Roles { get; set; }
    }
    [Table("tb_role")]
    public class RoleEntity
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public virtual List<UserEntity> Users { get; set; }
    }
}