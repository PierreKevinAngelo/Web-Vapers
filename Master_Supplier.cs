using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIVapers
{
    public class Master_Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 SupplierId { get; set; }
        public string Nama { get; set; }
        public string Telp_WA { get; set; }
        public string Alamat { get; set; }
    }
}
