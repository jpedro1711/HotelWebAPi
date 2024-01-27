using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
    [Route("api[controller]")]
    [ApiController]
    public class QuartoController : Controller
    {        
        [HttpPost]
        public void Post([FromBody] Quarto quarto)
        {
            using (var _context = new DB_HotelContext())
            {
                _context.Quarto.Add(quarto);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Quarto> Get()
        {
            using (var _context = new DB_HotelContext())
            {
               return _context.Quarto.ToList();
            }
        }

        [HttpGet("{numero}")]
        public IActionResult Get(string numero)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.Quarto.FirstOrDefault(t => t.QuartoCodigo.Equals(numero));
               if(item == null)               
                    return NotFound();
               
               return new ObjectResult(item);
            }
        }

        [HttpPut("{numero}")]
        public void Put(string numero, [FromBody] Quarto quarto)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.Quarto.FirstOrDefault(t => t.QuartoCodigo.Equals(numero));
               if(item == null)               
                    return;
               
               _context.Entry(item).CurrentValues.SetValues(quarto);
               _context.SaveChanges();
            }
        }

        [HttpDelete("{numero}")]
        public void Delete(string numero)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.Quarto.FirstOrDefault(t => t.QuartoCodigo.Equals(numero));
               if(item == null)               
                    return;
               
               _context.Quarto.Remove(item);
               _context.SaveChanges();
            }
        }
    }
}