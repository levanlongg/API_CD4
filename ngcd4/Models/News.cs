using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ngcd4.Models
{
    public partial class News
    {
        [Key]
        [Column("id")]
        [StringLength(10)]
        public string Id { get; set; }
        [Required]
        [Column("title")]
        [StringLength(500)]
        public string Title { get; set; }
        [Column("newtypeID")]
        [StringLength(10)]
        public string NewtypeId { get; set; }
        [Column("postTime", TypeName = "datetime")]
        public DateTime PostTime { get; set; }
        [Required]
        [Column("content")]
        public string Content { get; set; }

        [ForeignKey(nameof(NewtypeId))]
        [InverseProperty(nameof(NewsType.News))]
        public virtual NewsType Newtype { get; set; }
    }
}
