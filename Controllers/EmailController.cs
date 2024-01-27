using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmailController : Controller
  {
      [HttpPost]
      public void Post([FromBody] Email email)
      {
        using (var _context = new DB_HotelContext())
        {
          _context.Email.Add(email);
          _context.SaveChanges();
        }
      }

      [HttpGet]
      public List<Email> Get()
      {
        using (var _context = new DB_HotelContext())
        {
          return _context.Email.ToList();
        }
      }

      [HttpGet("{id}")]
      public IActionResult Get(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Email.FirstOrDefault(t => t.EmailCodigo == id);
          if (item == null)
          {
            return NotFound();
          }
          return Ok(item);
          // return new ObjectResult(item)
        }
      }

      [HttpPut("{id}")]
      public void Put(int id, [FromBody] Email email)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Email.FirstOrDefault(t => t.EmailCodigo == id);
          if (item == null)
          {
            return;
          }
          _context.Entry(item).CurrentValues.SetValues(email);
          _context.SaveChanges();
          // return new ObjectResult(item)
        }
      }

      [HttpDelete("{id}")]
      public void Delete(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Email.FirstOrDefault(t => t.EmailCodigo == id);
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