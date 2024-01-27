using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
  [Route("api/[controller]")]
  [ApiController]
  public class TelefoneController : Controller
  {
      [HttpPost]
      public void Post([FromBody] Telefone telefone)
      {
        using (var _context = new DB_HotelContext())
        {
          _context.Telefone.Add(telefone);
          _context.SaveChanges();
        }
      }

      [HttpGet]
      public List<Telefone> Get()
      {
        using (var _context = new DB_HotelContext())
        {
          return _context.Telefone.ToList();
        }
      }

      [HttpGet("{id}")]
      public IActionResult Get(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Telefone.FirstOrDefault(t => t.TelefoneCodigo == id);
          if (item == null)
          {
            return NotFound();
          }
          return Ok(item);
          // return new ObjectResult(item)
        }
      }

      [HttpPut("{id}")]
      public void Put(int id, [FromBody] Telefone telefone)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Telefone.FirstOrDefault(t => t.TelefoneCodigo == id);
          if (item == null)
          {
            return;
          }
          _context.Entry(item).CurrentValues.SetValues(telefone);
          _context.SaveChanges();
          // return new ObjectResult(item)
        }
      }

      [HttpDelete("{id}")]
      public void Delete(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Telefone.FirstOrDefault(t => t.TelefoneCodigo == id);
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