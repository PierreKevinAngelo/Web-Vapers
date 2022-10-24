using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIVapers.Data;

namespace WebAPIVapers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly ClassContext _classContext;

        public CustomerController(ClassContext classContext)
        {
            _classContext = classContext;
        }
       
        [HttpGet]
        public async Task<ActionResult<List<Master_Customer>>> get()
        {
            return Ok(await _classContext.Master_Customer.ToListAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<Master_Customer>> get(Int64 id)
        {
            var _customer = await _classContext.Master_Customer.FindAsync(id);
            if (_customer == null)
                return BadRequest("Custoemr not found");
            return Ok(_customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Master_Customer>>> AddCustomer(Master_Customer _Customer)
        {
            _classContext.Master_Customer.Add(_Customer);
            await _classContext.SaveChangesAsync();

            return Ok(await _classContext.Master_Customer.ToListAsync());
        }
        
        [HttpPut]
        public async Task<ActionResult<List<Master_Customer>>> UpdateCustomer(Master_Customer request)
        {
            var DB_Vapers = await _classContext.Master_Customer.FindAsync(request.CustomerID);
            if (DB_Vapers == null)
                return BadRequest("Hero not found");

            DB_Vapers.Nama = request.Nama;
            DB_Vapers.WA = request.WA;
            DB_Vapers.Jenis_Customer = request.Jenis_Customer;
            DB_Vapers.Alamat = request.Alamat;
            DB_Vapers.Email = request.Email;
            DB_Vapers.Tgl_Lahir = request.Tgl_Lahir;
            DB_Vapers.Status_Aktif = request.Status_Aktif;

            await _classContext.SaveChangesAsync();

            return Ok(await _classContext.Master_Customer.ToListAsync());
        }
        
        [HttpDelete("id")]
        public async Task<ActionResult<List<Master_Customer>>> Delete(Int64 id)
        {
            var DB_Vapers = await _classContext.Master_Customer.FindAsync(id);
            if (DB_Vapers == null)
                return BadRequest("CustomerID not found");

            _classContext.Master_Customer.Remove(DB_Vapers);
            await _classContext.SaveChangesAsync();

            return Ok(await _classContext.Master_Customer.ToListAsync());
        }
    }
}
