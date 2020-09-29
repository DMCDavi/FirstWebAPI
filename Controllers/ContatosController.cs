using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private static List<Contato> contatos = new List<Contato>();

        public ContatosController()
        {
            if (contatos.Count == 0)
            {
                contatos.Add(
                    new Contato
                    {
                        ID = 1,
                        Nome = "Davi",
                        Email = "davi@hotmail.com",
                        Celular = "75998712714",
                        Ativo = true
                    }
                );
                contatos.Add(
                    new Contato
                    {
                        ID = 2,
                        Nome = "Lapa",
                        Email = "lapa@hotmail.com",
                        Celular = "45646465465",
                        Ativo = true
                    }
                );
                contatos.Add(
                    new Contato
                    {
                        ID = 3,
                        Nome = "Atari",
                        Email = "atari@hotmail.com",
                        Celular = "12498765462",
                        Ativo = true
                    }
                );
            }
        }

        // GET: api/<ContatosController>
        [HttpGet]
        public List<Contato> Get()
        {
            return contatos;
        }

        // GET api/<ContatosController>/5
        [HttpGet("{id}")]
        public Contato Get(int id)
        {
            return contatos.Find(c => c.ID == id);
        }

        // POST api/<ContatosController>
        [HttpPost]
        public IActionResult Post([FromBody] Contato c)
        {
            if (!contatos.Any(ct => ct.ID == c.ID))
            {
                contatos.Add(c);
                return Ok(c);
            }
            else
                return BadRequest();
        }

        // PUT api/<ContatosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContatosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
