using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIVapers
{
    public class Master_Barang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 IDBarang { get; set; }
        public string Nama_Barang { get; set; }
        public string Jenis_Barang { get; set; }
        public decimal Harga_Beli { get; set; }
        public decimal Harga_Jual { get; set; }
        public decimal Harga_Jual_Ppn { get; set; }
        public string Spesifikasi { get; set; }

    }
}
