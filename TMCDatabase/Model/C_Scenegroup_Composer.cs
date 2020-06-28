using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBTryout.Model
{
    public class C_Scenegroup_Composer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Scenegroup_composer_id { get; set; }

        public int FK_scenegroup_id { get; set; }

        public int FK_composer_id { get; set; }

        [ForeignKey("FK_scenegroup_id")]
        public Scenegroup Scenegroup { get; set; }

        [ForeignKey("FK_composer_id")]
        public Composer Composer { get; set; }

    }
}
