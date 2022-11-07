using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SqlLiteDBApp.Standard.Entities
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Words")]
    public partial class WordDB
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.MaxLength(128)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(256)]

        public string? Translate { get; set; }
        [System.ComponentModel.DataAnnotations.MaxLength(256)]
        public string? Descriptions { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(256)]
        public string? Transcription { get; set; }


        public bool IsVisible { get; set; }

    }
}
