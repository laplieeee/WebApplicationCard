using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationCard.Models
{
    public class CardViewModel
    {
        public long IdCard { get; set; }
        [DisplayName("IdNum")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "กรุณาระบุเลขบัตรประจำตัวประชาชน 13 หลัก")]
        public long IdNum { get; set; }

        [DisplayName("FristName")]
        public string FristName { get; set; }

        [DisplayName("LastName")]
        public string LastName { get; set; }

        [DisplayName("Birthday")]
        public DateTime Birthday { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Religion")]
        public string Religion { get; set; }
        [DisplayName("Outday")]
        public DateTime Outday { get; set; }
        [DisplayName("EXPday")]
        public DateTime EXPday { get; set; }

        [DisplayName("ImageUrl")]
        public string ImageUrl { get; set; }

        [NotMapped]
        [DisplayName("Picture")]
        public IFormFile Picture { get; set; }
    }
}
