using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
  [Route("api/[controller]")]
  [ApiController]
  public class ConsumoController : Controller
  {
      [HttpPost]
      public void Post([FromBody] Consumo consumo)
      {
        using (var _context = new DB_HotelContext())
        {
          _context.Consumo.Add(consumo);
          _context.SaveChanges();
        }
      }

      [HttpGet]
      public List<Consumo> Get()
      {
        using (var _context = new DB_HotelContext())
        {
          return _context.Consumo.ToList();
        }
      }

      [HttpGet("{id}")]
      public IActionResult Get(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Consumo.FirstOrDefault(t => t.ConsumoCodigo == id);
          if (item == null)
          {
            return NotFound();
          }
          return Ok(item);
          // return new ObjectResult(item)
        }
      }

      [HttpPut("{id}")]
      public void Put(int id, [FromBody] Consumo consumo)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Consumo.FirstOrDefault(t => t.ConsumoCodigo == id);
          if (item == null)
          {
            return;
          }
          _context.Entry(item).CurrentValues.SetValues(consumo);
          _context.SaveChanges();
          // return new ObjectResult(item)
        }
      }

      [HttpDelete("{id}")]
      public void Delete(int id)
      {
        using (var _context = new DB_HotelContext())
        {
          var item = _context.Consumo.FirstOrDefault(t => t.ConsumoCodigo == id);
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