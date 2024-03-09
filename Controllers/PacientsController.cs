using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace API.Controllers
{
    public class PacientsController : Controller
    {
        private readonly Med1Context _context;

        public PacientsController(Med1Context context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("/PacientsController/Create")]
        public async Task<ActionResult> Create([FromBody] Pacient pacient)
        {
            var toChek = _context.Pacients.Where(op => op.PasportSeria == pacient.PasportSeria).FirstOrDefault();
            if (toChek !=null)
            {
                return Ok(new
                {
                    StatusCode = 201

                });
                

            }

            Pacient create = new()
            {
                F = pacient.F,
                I = pacient.I,
                O = pacient.O,
                Phone = pacient.Phone,
                Email = pacient.Email,
                Born = pacient.Born,
                PasportSeria = pacient.PasportSeria,
                PasportAdres = pacient.PasportAdres,
                Rabota = pacient.Rabota

            };

            await _context.Pacients.AddAsync(create);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                StatusCode = 200
            });

        }

    }
}
