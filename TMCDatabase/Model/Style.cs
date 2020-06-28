using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TMCDatabase.Model
{
    public class Style
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Style_id { get; set; }

        [ForeignKey("ParentStyle")]
        public int? Parent_style_id { get; set; }

        [ForeignKey("ParentAltStyle")]
        public int? Alt_style_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Weight { get; set; }

        public virtual Style ParentStyle { get; set; }
        public virtual Style ParentAltStyle { get; set; }
    }
}
