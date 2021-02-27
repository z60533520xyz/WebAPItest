using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPItest.Models
{
    public class ApiRequest
    {
        public string Agency { get; set; }
        public string Medium { get; set; }
        public string InsType { get; set; }
        public string PayId { get; set; }
        public string PayIdName { get; set; }
        public string PayIdSex { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PayIdBirthday { get; set; }
        public string PayIdZipM { get; set; }
        public string PayIdCityM { get; set; }
        public string PayIdAreaM { get; set; }
        public string PayIdAddrM { get; set; }
        public string PayIdTelH { get; set; }
        public string PayIdTelMv { get; set; }
        public string PayIdEmail { get; set; }
        public string ApplyNo { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DueDt { get; set; }
        public string TotInv { get; set; }
        public string SendType { get; set; }
        public string Englishpolicy { get; set; }
        public string Location { get; set; }
        public string LocationCode { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TravelDateFrom { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TravelDateEnd { get; set; }
        public string TravelDateHour { get; set; }
        public string Id { get; set; }
        public string EngName { get; set; }
        public string Passport { get; set; }
        public string Idname { get; set; }
        public string IdSex { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime IdBirthday { get; set; }
        public string IdCityM { get; set; }
        public string IdAreaM { get; set; }
        public string IdZipM { get; set; }
        public string IdaddrM { get; set; }
        public string IdtelH { get; set; }
        public string IdtelMv { get; set; }
        public string IdEmail { get; set; }
        public string Relation { get; set; }
        public string IdDeclarationOFGuardian { get; set; }
        public int IdJobClass { get; set; }
        public string PolicyPregnancy { get; set; }
        public string PolicyOtherMM { get; set; }
        public string Relationship { get; set; }
        public string BenId { get; set; }
        public string BenName { get; set; }
        public string BenPhone { get; set; }
        public string BenZipM { get; set; }
        public string BenAddrM { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BenProportion { get; set; }
        public int BenSeq { get; set; }
        public string ProdCode { get; set; }

    }
}
