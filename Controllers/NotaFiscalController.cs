using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
    [Route("api[controller]")]
    [ApiController]
    public class NotaFiscalController : Controller
    {        
        [HttpPost]
        public void Post([FromBody] NotaFiscal notaFiscal)
        {
            using (var _context = new DB_HotelContext())
            {
                _context.NotaFiscal.Add(notaFiscal);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<NotaFiscal> Get()
        {
            using (var _context = new DB_HotelContext())
            {
               return _context.NotaFiscal.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.NotaFiscal.FirstOrDefault(t => t.NotaFiscalCodigo == id);
               if(item == null)               
                    return NotFound();
               
               return new ObjectResult(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] NotaFiscal notaFiscal)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.NotaFiscal.FirstOrDefault(t => t.NotaFiscalCodigo == id);
               if(item == null)               
                    return;
               
               _context.Entry(item).CurrentValues.SetValues(notaFiscal);
               _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.NotaFiscal.FirstOrDefault(t => t.NotaFiscalCodigo == id);
               if(item == null)               
                    return;
               
               _context.NotaFiscal.Remove(item);
               _context.SaveChanges();
            }
        }
    }
}