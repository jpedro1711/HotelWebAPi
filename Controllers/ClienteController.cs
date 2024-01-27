using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClienteController : Controller
  {
      [HttpPost]
      public void Post([FromBody] Cliente cliente)
      {
        using (var _context = new DB_HotelContext())
        {
          _context.Cliente.Add(cliente);
          _context.SaveChanges();
        }
      }

      [HttpGet]
      public List<Cliente> Get()
      {
        using (var _context = new DB_HotelContext())
        {
          return _context.Cliente.ToList();
        }
      }

      [HttpGet("{id}")]
      public IActionResult Get(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Cliente.FirstOrDefault(t => t.ClienteCodigo == id);
          if (item == null)
          {
            return NotFound();
          }
          return Ok(item);
          // return new ObjectResult(item)
        }
      }

      [HttpPut("{id}")]
      public void Put(int id, [FromBody] Cliente cliente)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Cliente.FirstOrDefault(t => t.ClienteCodigo == id);
          if (item == null)
          {
            return;
          }
          _context.Entry(item).CurrentValues.SetValues(cliente);
          _context.SaveChanges();
          // return new ObjectResult(item)
        }
      }

      [HttpDelete("{id}")]
      public void Delete(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Cliente.FirstOrDefault(t => t.ClienteCodigo == id);
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