using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIVapers.Data;

namespace WebAPIVapers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SupplierController : ControllerBase
    {
        private readonly ClassContext _classContext;

        public SupplierController(ClassContext classContext)
        {
            _classContext = classContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Master_Supplier>>> get()
        {
            return Ok(await _classContext.Master_Supplier.ToListAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<Master_Supplier>> get(Int64 id)
        {
            var _supplier = await _classContext.Master_Supplier.FindAsync(id);
            if (_supplier == null)
                return BadRequest("Supplier not found");
            return Ok(_supplier);
        }

        [HttpPost]
        public async Task<ActionResult<List<Master_Supplier>>> AddSupplier(Master_Supplier _supplier)
        {
            _classContext.Master_Supplier.Add(_supplier);
            await _classContext.SaveChangesAsync();

            return Ok(await _classContext.Master_Supplier.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Master_Supplier>>> UpdateSupplier(Master_Supplier request)
        {
            var DB_Vapers = await _classContext.Master_Supplier.FindAsync(request.SupplierId);
            if (DB_Vapers == null)
                return BadRequest("Supplier not found");

            DB_Vapers.Nama = request.Nama;
            DB_Vapers.Telp_WA = request.Telp_WA;
            DB_Vapers.Alamat = request.Alamat;           
            await _classContext.SaveChangesAsync();

            return Ok(await _classContext.Master_Supplier.ToListAsync());
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<Master_Supplier>>> Delete(Int64 id)
        {
            var DB_Vapers = await _classContext.Master_Supplier.FindAsync(id);
            if (DB_Vapers == null)
                return BadRequest("SupplierID not found");

            _classContext.Master_Supplier.Remove(DB_Vapers);
            await _classContext.SaveChangesAsync();

            return Ok(await _classContext.Master_Supplier.ToListAsync());
        }
    }
}
