using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIVapers
{
    public class Master_Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 CustomerID { get; set; }
        public string Nama { get; set; }
        public string WA { get; set; }
        public string Jenis_Customer { get; set; }
        public string Alamat { get; set; }
        public string Email { get; set; }
        public DateTime Tgl_Lahir { get; set; }
        public Boolean Status_Aktif { get; set; }

    }
}
