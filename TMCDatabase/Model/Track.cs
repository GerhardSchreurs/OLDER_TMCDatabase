using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMCDatabase.Model
{
    public class Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackID { get; set; }

        [Index("IndexGuid", IsUnique = true)]
        public Guid Md5 { get; set; }

        [Required]
        [ForeignKey("ParentStyle")]
        public int FK_tracker_id { get; set; }
        public int? FK_style_id { get; set; }
        public int? FK_composer_id { get; set; }

        [Required]
        public bool Is_processed { get; set; }

        [Required]
        public DateTime Date_track_created { get; set; }
        public DateTime? Date_track_modified { get; set; }

        [Required]
        public DateTime Date_created { get; set; }

        [Required]
        public DateTime Date_modified { get; set; }
        public DateTime? Date_processed { get; set; }

        [Required]
        [StringLength(25)] //TODO: check
        public string Songname { get; set; }

        [Required]
        [StringLength(32)] //TODO: Split longer than 32
        public string FileName { get; set; }

        [StringLength(50)]
        public string ComposerName { get; set; }

        [StringLength(50)] //TODO: check
        public string TrackerMeta { get; set; }

        [Required]
        public Int16 Speed { get; set; }

        [Required]
        public Int16 Tempo { get; set; }

        [Required]
        public Int16 Bpm { get; set; }

        public string SampleText { get; set; }
        public Int16 SampleCount { get; set; }
        public Int16 SampleLinecount { get; set; }

        public string InstrumentText { get; set; }
        public Int16 InstrumentCount { get; set; }
        public Int16 InstrumentLinecount { get; set; }

        public string SongText { get; set; }


        [ForeignKey("FK_tracker_id")]
        public Tracker Tracker { get; set; }

        [ForeignKey("FK_style_id")]
        public Style Style { get; set; }

        [ForeignKey("FK_composer_id")]
        public Composer Composer { get; set; }
    }
}
