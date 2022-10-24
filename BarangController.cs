using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIVapers.Data;

namespace WebAPIVapers.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class BarangController : ControllerBase
    {
        private readonly ClassContext _classContext;

        public BarangController(ClassContext classContext)
        {
            _classContext = classContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Master_Barang>>> get()
        {
            return Ok(await _classContext.Master_Barang.ToListAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<Master_Barang>> get(Int64 id)
        {
            var _barang = await _classContext.Master_Barang.FindAsync(id);
            if (_barang == null)
                return BadRequest("Barang not found");
            return Ok(_barang);
        }

        [HttpPost]
        public async Task<ActionResult<List<Master_Barang>>> AddBarang(Master_Barang _barang)
        {
            _classContext.Master_Barang.Add(_barang);
            await _classContext.SaveChangesAsync();

            return Ok(await _classContext.Master_Barang.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Master_Barang>>> UpdateBarang(Master_Barang request)
        {
            var DB_Vapers = await _classContext.Master_Barang.FindAsync(request.IDBarang);
            if (DB_Vapers == null)
                return BadRequest("Barang not found");

            DB_Vapers.Nama_Barang = request.Nama_Barang;
            DB_Vapers.Jenis_Barang = request.Jenis_Barang;
            DB_Vapers.Harga_Beli = request.Harga_Beli;
            DB_Vapers.Harga_Jual = request.Harga_Jual;
            DB_Vapers.Harga_Jual_Ppn = request.Harga_Jual_Ppn;
            await _classContext.SaveChangesAsync();

            return Ok(await _classContext.Master_Barang.ToListAsync());
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<Master_Barang>>> Delete(Int64 id)
        {
            var DB_Vapers = await _classContext.Master_Barang.FindAsync(id);
            if (DB_Vapers == null)
                return BadRequest("Barang not found");

            _classContext.Master_Barang.Remove(DB_Vapers);
            await _classContext.SaveChangesAsync();

            return Ok(await _classContext.Master_Barang.ToListAsync());
        }
    }

}
