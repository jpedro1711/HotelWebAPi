using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
  [Route("api/[controller]")]
  [ApiController]
  public class TipoFuncionarioController : Controller
  {
      [HttpPost]
      public void Post([FromBody] TipoFuncionario tipo)
      {
        using (var _context = new DB_HotelContext())
        {
          _context.TipoFuncionario.Add(tipo);
          _context.SaveChanges();
        }
      }

      [HttpGet]
      public List<TipoFuncionario> Get()
      {
        using (var _context = new DB_HotelContext())
        {
          return _context.TipoFuncionario.ToList();
        }
      }

      [HttpGet("{id}")]
      public IActionResult Get(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.TipoFuncionario.FirstOrDefault(t => t.TipoFuncionarioCodigo == id);
          if (item == null)
          {
            return NotFound();
          }
          return Ok(item);
          // return new ObjectResult(item)
        }
      }

      [HttpPut("{id}")]
      public void Put(int id, [FromBody] TipoFuncionario tipoFuncionario)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.TipoFuncionario.FirstOrDefault(t => t.TipoFuncionarioCodigo == id);
          if (item == null)
          {
            return;
          }
          _context.Entry(item).CurrentValues.SetValues(tipoFuncionario);
          _context.SaveChanges();
          // return new ObjectResult(item)
        }
      }

      [HttpDelete("{id}")]
      public void Delete(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.TipoFuncionario.FirstOrDefault(t => t.TipoFuncionarioCodigo == id);
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