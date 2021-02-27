using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPItest.Models
{
    public class IdInformation
    {
        /*[Key]
        public int IdInformationId { get; set; }*/
        [Required]
        [StringLength(10)]
        public string Id { get; set; }
        [MaxLength(50)]
        public string EngName { get; set; }
        [MaxLength(50)]
        public string Passport { get; set; }
        [Required]
        [MaxLength(50)]
        public string Idname { get; set; }
        [Required]
        [StringLength(1)]
        public string IdSex { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime IdBirthday { get; set; }
        [Required]
        [MaxLength(3)]
        public string IdCityM { get; set; }
        [Required]
        [MaxLength(4)]
        public string IdAreaM { get; set; }
        [Required]
        [MaxLength(5)]
        public string IdZipM { get; set; }
        [Required]
        [MaxLength(50)]
        public string IdaddrM { get; set; }
        [MaxLength(13)]
        public string IdtelH { get; set; }
        [Required]
        [MaxLength(12)]
        public string IdtelMv { get; set; }
        [Required]
        [MaxLength(50)]
        public string IdEmail { get; set; }
        [StringLength(1)]
        public string Relation { get; set; }
        [Required]
        [StringLength(1)]
        public string IdDeclarationOFGuardian { get; set; }
        [Required]
        public int IdJobClass { get; set; }
        [StringLength(1)]
        public string PolicyPregnancy { get; set; }
        [StringLength(1)]
        public string PolicyOtherMM { get; set; }

        [Key]
        [ForeignKey("PayIdInformation")]
        public string Guid { get; set; }
        [JsonIgnore]
        public PayIdInformation PayIdInformation { get; set; }
    }
}
