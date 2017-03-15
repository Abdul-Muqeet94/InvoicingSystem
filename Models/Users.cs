
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleInvoices {

    public class identity{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id {get;set;}
        public bool enable {get;set;}
    }
    public class Users:identity{
        public string name {get;set;}
        public string password {get;set;}
    }

}