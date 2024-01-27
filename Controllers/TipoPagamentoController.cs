using Microsoft.AspNetCore.Mvc;

namespace DB_Hotel
{
    [Route("api[controller]")]
    [ApiController]
    public class TipoPagamentoController : Controller
    {        
        [HttpPost]
        public void Post([FromBody] TipoPagamento tipoPagamento)
        {
            using (var _context = new DB_HotelContext())
            {
                _context.TipoPagamento.Add(tipoPagamento);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<TipoPagamento> Get()
        {
            using (var _context = new DB_HotelContext())
            {
               return _context.TipoPagamento.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.TipoPagamento.FirstOrDefault(t => t.TipoPagamentoCodigo == id);
               if(item == null)               
                    return NotFound();
               
               return new ObjectResult(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TipoPagamento tipoPagamento)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.TipoPagamento.FirstOrDefault(t => t.TipoPagamentoCodigo == id);
               if(item == null)               
                    return;
               
               _context.Entry(item).CurrentValues.SetValues(tipoPagamento);
               _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.TipoPagamento.FirstOrDefault(t => t.TipoPagamentoCodigo == id);
               if(item == null)               
                    return;
               
               _context.TipoPagamento.Remove(item);
               _context.SaveChanges();
            }
        }
    }
}