using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationCard.Models.DBEntities
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public long IdCard { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        [DisplayName("IdNum")]
        public long IdNum { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("FristName")]
        public string FristName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("LastName")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Birthday")]
        public DateTime Birthday { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Religion")]
        public string Religion { get; set; }
        [Required]
        [DisplayName("Outday")]
        public DateTime Outday { get; set; }
        [Required]
        [DisplayName("EXPday")]
        public DateTime EXPday { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [DisplayName("ImageUrl")]
        public string ImageUrl { get; set; }

        [NotMapped]
        [DisplayName("Picture")]
        public IFormFile Picture { get; set; }
    }
}
