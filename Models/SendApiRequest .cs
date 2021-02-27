using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPItest.Models
{
    public class SendApiRequest:ApiRequest
    {
        [Key]
        public string Guid { get; set; }
    }
}
