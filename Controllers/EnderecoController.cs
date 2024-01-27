using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
  [Route("api/[controller]")]
  [ApiController]
  public class EnderecoController : Controller
  {
      [HttpPost]
      public void Post([FromBody] Endereco endereco)
      {
        using (var _context = new DB_HotelContext())
        {
          _context.Endereco.Add(endereco);
          _context.SaveChanges();
        }
      }

      [HttpGet]
      public List<Endereco> Get()
      {
        using (var _context = new DB_HotelContext())
        {
          return _context.Endereco.ToList();
        }
      }

      [HttpGet("{id}")]
      public IActionResult Get(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Endereco.FirstOrDefault(t => t.EnderecoCodigo == id);
          if (item == null)
          {
            return NotFound();
          }
          return Ok(item);
          // return new ObjectResult(item)
        }
      }

      [HttpPut("{id}")]
      public void Put(int id, [FromBody] Endereco endereco)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Endereco.FirstOrDefault(t => t.EnderecoCodigo == id);
          if (item == null)
          {
            return;
          }
          _context.Entry(item).CurrentValues.SetValues(endereco);
          _context.SaveChanges();
          // return new ObjectResult(item)
        }
      }

      [HttpDelete("{id}")]
      public void Delete(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Endereco.FirstOrDefault(t => t.EnderecoCodigo == id);
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