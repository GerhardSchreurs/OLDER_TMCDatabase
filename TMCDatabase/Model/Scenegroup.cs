using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMCDatabase.Model
{
    public class Scenegroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Scenegroup_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
