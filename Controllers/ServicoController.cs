using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
  [Route("api/[controller]")]
  [ApiController]
  public class ServicoController : Controller
  {
      [HttpPost]
      public void Post([FromBody] Servico servico)
      {
        using (var _context = new DB_HotelContext())
        {
          _context.Servico.Add(servico);
          _context.SaveChanges();
        }
      }

      [HttpGet]
      public List<Servico> Get()
      {
        using (var _context = new DB_HotelContext())
        {
          return _context.Servico.ToList();
        }
      }

      [HttpGet("{id}")]
      public IActionResult Get(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Servico.FirstOrDefault(t => t.ServicoCodigo == id);
          if (item == null)
          {
            return NotFound();
          }
          return Ok(item);
          // return new ObjectResult(item)
        }
      }

      [HttpPut("{id}")]
      public void Put(int id, [FromBody] Servico servico)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Servico.FirstOrDefault(t => t.ServicoCodigo == id);
          if (item == null)
          {
            return;
          }
          _context.Entry(item).CurrentValues.SetValues(servico);
          _context.SaveChanges();
          // return new ObjectResult(item)
        }
      }

      [HttpDelete("{id}")]
      public void Delete(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Servico.FirstOrDefault(t => t.ServicoCodigo == id);
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