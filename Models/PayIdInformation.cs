using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPItest.Models
{
    public class PayIdInformation
    {
        [Key]
        [StringLength(36)]
        public string Guid { get; set; }
        [Required]
        [MaxLength(50)]
        public string Agency { get; set; }
        [MaxLength(50)]
        public string Medium { get; set; }
        [Required]
        [MaxLength(5)]
        public string InsType { get; set; }
        [Required]
        [StringLength(10)]
        public string PayId { get; set; }
        [Required]
        [MaxLength(50)]
        public string PayIdName { get; set; }
        [Required]
        [StringLength(1)]
        public string PayIdSex { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PayIdBirthday { get; set; }
        [Required]
        [MaxLength(5)]
        public string PayIdZipM { get; set; }
        [Required]
        [MaxLength(3)]
        public string PayIdCityM { get; set; }
        [Required]
        [MaxLength(4)]
        public string PayIdAreaM { get; set; }
        [Required]
        [MaxLength(50)]
        public string PayIdAddrM { get; set; }
        [MaxLength(15)]
        public string PayIdTelH { get; set; }
        [Required]
        [MaxLength(12)]
        public string PayIdTelMv { get; set; }
        [Required]
        [MaxLength(50)]
        public string PayIdEmail { get; set; }
        [Required]
        [StringLength(12)]
        public string ApplyNo { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DueDt { get; set; }
        [Required]
        [MaxLength(12)]
        public string TotInv { get; set; }
        [Required]
        [MaxLength(1)]
        public string SendType { get; set; }
        [MaxLength(1)]
        public string Englishpolicy { get; set; }
        [Required]
        [MaxLength(1)]
        public string Location { get; set; }
        [Required]
        [MaxLength(4)]
        public string LocationCode { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TravelDateFrom { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TravelDateEnd { get; set; }
        [Required]
        [StringLength(2)]
        public string TravelDateHour { get; set; }

        public IdInformation IdInformation { get; set; }
        //public List<BenIdInformation> BenIdInformation { get; set; }
        public BenIdInformation BenIdInformation { get; set; }
        public Product Product { get; set; }

    }
}
