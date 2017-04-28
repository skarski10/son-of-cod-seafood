using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonOfCod.Models
{
    [Table("MailingList")]
    public class MailingList
    {
        [Key]
        public int MailingListId { get; set; }
        public string Email { get; set; }

    }
}
