using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
  [Route("api/[controller]")]
  [ApiController]
  public class FuncionarioController : Controller
  {
      [HttpPost]
      public void Post([FromBody] Funcionario funcionario)
      {
        using (var _context = new DB_HotelContext())
        {
          _context.Funcionario.Add(funcionario);
          _context.SaveChanges();
        }
      }

      [HttpGet]
      public List<Funcionario> Get()
      {
        using (var _context = new DB_HotelContext())
        {
          return _context.Funcionario.ToList();
        }
      }

      [HttpGet("{id}")]
      public IActionResult Get(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Funcionario.FirstOrDefault(t => t.FuncionarioCodigo == id);
          if (item == null)
          {
            return NotFound();
          }
          return Ok(item);
          // return new ObjectResult(item)
        }
      }

      [HttpPut("{id}")]
      public void Put(int id, [FromBody] Funcionario funcionario)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Funcionario.FirstOrDefault(t => t.FuncionarioCodigo == id);
          if (item == null)
          {
            return;
          }
          _context.Entry(item).CurrentValues.SetValues(funcionario);
          _context.SaveChanges();
          // return new ObjectResult(item)
        }
      }

      [HttpDelete("{id}")]
      public void Delete(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Funcionario.FirstOrDefault(t => t.FuncionarioCodigo == id);
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