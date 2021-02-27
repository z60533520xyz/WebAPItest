using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPItest.Models
{
    public class Product
    {
        //public int ProductId { get; set; }
        [Required]
        [MaxLength(20)]
        public string ProdCode { get; set; }

        [Key]
        [ForeignKey("PayIdInformation")]
        public string Guid { get; set; }
        [JsonIgnore]
        public PayIdInformation PayIdInformation { get; set; }
    }
}
