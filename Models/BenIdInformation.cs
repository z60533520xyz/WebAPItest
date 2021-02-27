using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPItest.Models
{
    public class BenIdInformation
    {
        //[Key]
        //public int BenIdInformationId { get; set; }
        [Required]
        [StringLength(1)]
        public string Relationship { get; set; }
        [StringLength(10)]
        public string BenId { get; set; }
        [MaxLength(50)]
        public string BenName { get; set; }
        [MaxLength(12)]
        public string BenPhone { get; set; }
        [MaxLength(5)]
        public string BenZipM { get; set; }
        [MaxLength(50)]
        public string BenAddrM { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BenProportion { get; set; }
        public int BenSeq { get; set; }
        [Key]
        [ForeignKey("PayIdInformation")]
        public string Guid { get; set; }
        [JsonIgnore]
        public PayIdInformation PayIdInformation { get; set; }
    }
}
