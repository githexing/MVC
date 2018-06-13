namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_user
    {
        public long ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
