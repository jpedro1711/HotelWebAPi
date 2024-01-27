using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
    [Route("api[controller]")]
    [ApiController]
    public class TipoQuartoController : Controller
    {        
        [HttpPost]
        public void Post([FromBody] TipoQuarto tipoQuarto)
        {
            using (var _context = new DB_HotelContext())
            {                
                _context.TipoQuarto.Add(tipoQuarto);
                tipoQuarto?.Filial?.TiposQuartos?.Add(tipoQuarto);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<TipoQuarto> Get()
        {
            using (var _context = new DB_HotelContext())
            {
               return _context.TipoQuarto.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.TipoQuarto.FirstOrDefault(t => t.TipoQuartoCodigo == id);
               if(item == null)               
                    return NotFound();
               
               return new ObjectResult(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TipoQuarto tipoQuarto)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.TipoQuarto.FirstOrDefault(t => t.TipoQuartoCodigo == id);
               if(item == null)               
                    return;
               
               _context.Entry(item).CurrentValues.SetValues(tipoQuarto);
               _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.TipoQuarto.FirstOrDefault(t => t.TipoQuartoCodigo == id);
               if(item == null)               
                    return;
               
               _context.TipoQuarto.Remove(item);
               _context.SaveChanges();
            }
        }
    }
}