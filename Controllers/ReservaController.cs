using Microsoft.AspNetCore.Mvc;
using System;

namespace DB_Hotel
{
    [Route("api[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {        
        [HttpPost]
        public void Post([FromBody] Reserva reserva)
        {
            using (var _context = new DB_HotelContext())
            {   

                Quarto? q = _context.Quarto.FirstOrDefault(t => t.QuartoCodigo == reserva.QuartoCodigo);
                reserva.Quarto = q;


                TimeSpan duration = reserva.DataFim.Subtract(reserva.DataInicio);
                int days = duration.Days;

                 TipoQuarto? tq = _context.TipoQuarto.FirstOrDefault(t => t.TipoQuartoCodigo == q.TipoQuartoCodigo	);

                 decimal ?valDiaria = tq.Valor;
                 double ?valFinal = (double)(days * valDiaria);

                 if (q.CapacidadeOpc == true)
                 {
                    reserva.ValorTotal = (decimal?)(valFinal * 1.25);
                 }
                 else
                 {
                    reserva.ValorTotal = (decimal?)valFinal;
                 }

                _context.Reserva.Add(reserva);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Reserva> Get()
        {
            using (var _context = new DB_HotelContext())
            {
               return _context.Reserva.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.Reserva.FirstOrDefault(t => t.ReservaCodigo == id);
               if(item == null)               
                    return NotFound();
               
               return new ObjectResult(item);
            }
        }

        [HttpPut("cancel/{id}")]
        public IActionResult Cancel(int id)        {

            using (var _context = new DB_HotelContext())
            {          
                Reserva? reserva = _context.Reserva.FirstOrDefault(t => t.ReservaCodigo == id);
                if(reserva == null)               
                    return NotFound();

                Filial? f = _context.Filial.FirstOrDefault(t => t.FilialCodigo == reserva.FilialCodigo);
                reserva.Filial = f;

                Quarto? q = _context.Quarto.FirstOrDefault(t => t.QuartoCodigo == reserva.QuartoCodigo);
                reserva.Quarto = q;
                
                TimeSpan duration = DateTime.Now.Subtract(reserva.DataInicio);
                int days = duration.Days;
                
                TipoQuarto? tq = _context.TipoQuarto.FirstOrDefault(t => t.TipoQuartoCodigo == q.TipoQuartoCodigo	);
                var item = _context.Reserva.FirstOrDefault(t => t.ReservaCodigo == id);
                if (days <= 1) 
                {
                    reserva.ValorTotal = tq.Valor;
                    reserva.Cancelada = true;
                    reserva.CobrancaDiaria = true;
                    _context.Entry(item).CurrentValues.SetValues(reserva);
                    _context.SaveChanges();
                    return Ok();
                }     

                return BadRequest();               
               
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Reserva reserva)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.Reserva.FirstOrDefault(t => t.ReservaCodigo == id);
               if(item == null)               
                    return;
               
               _context.Entry(item).CurrentValues.SetValues(reserva);
               _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new DB_HotelContext())
            {               
               var item = _context.Reserva.FirstOrDefault(t => t.ReservaCodigo == id);
               if(item == null)               
                    return;
               
               _context.Reserva.Remove(item);
               _context.SaveChanges();
            }
        }
    }
}