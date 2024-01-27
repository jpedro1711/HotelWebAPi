using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContaClienteController : Controller
  {
      [HttpPost]
      public void Post([FromBody] ContaCliente cliente)
      {
        using (var _context = new DB_HotelContext())
        {
          _context.ContaCliente.Add(cliente);
          _context.SaveChanges();
        }
      }

      [HttpGet]
      public List<ContaCliente> Get()
      {
        using (var _context = new DB_HotelContext())
        {
          return _context.ContaCliente.ToList();
        }
      }

      [HttpGet("{id}")]
      public IActionResult Get(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.ContaCliente.FirstOrDefault(t => t.ContaClienteCodigo == id);
          if (item == null)
          {
            return NotFound();
          }
          return Ok(item);
          // return new ObjectResult(item)
        }
      }

      [HttpPut("{id}")]
      public void Put(int id, [FromBody] ContaCliente contaCliente)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.ContaCliente.FirstOrDefault(t => t.ContaClienteCodigo == id);
          if (item == null)
          {
            return;
          }
          _context.Entry(item).CurrentValues.SetValues(contaCliente);
          _context.SaveChanges();
          // return new ObjectResult(item)
        }
      }

      [HttpDelete("{id}")]
      public void Delete(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.ContaCliente.FirstOrDefault(t => t.ContaClienteCodigo == id);
          if (item == null)
          {
            return;
          }
          _context.Remove(item);
          _context.SaveChanges();
          // return new ObjectResult(item)
        }
      }
  }
}