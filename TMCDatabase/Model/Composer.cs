using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Text;

namespace TMCDatabase.Model
{
    public class Composer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Composer_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
