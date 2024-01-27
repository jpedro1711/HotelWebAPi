using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
    [Route("api[controller]")]
    [ApiController]
    public class FilialController : Controller
    {        
        [HttpPost]
        public void Post([FromBody] Filial filial)
        {
            using (var _context = new DB_HotelContext())
            {
                _context.Filial.Add(filial);                                
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Filial> Get()
        {
            using (var _context = new DB_HotelContext())
            {
               return _context.Filial.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.Filial.FirstOrDefault(t => t.FilialCodigo == id);
               if(item == null)               
                    return NotFound();
               
               return new ObjectResult(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Filial filial)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.Filial.FirstOrDefault(t => t.FilialCodigo == id);
               if(item == null)               
                    return;
               
               _context.Entry(item).CurrentValues.SetValues(filial);
               _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.Filial.FirstOrDefault(t => t.FilialCodigo == id);
               if(item == null)               
                    return;
               
               _context.Filial.Remove(item);
               _context.SaveChanges();
            }
        }
    }
}