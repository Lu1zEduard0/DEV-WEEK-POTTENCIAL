using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

using src.Models;
using src.Persistence;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase  //Herdando da classe ControllerBase
{
    private DatabaseContext _context { get; set; }
    public PersonController(DatabaseContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public ActionResult<List<Person>> Get()
    {

        var result = _context.Pessoas.Include(p => p.contratos).ToList();

        if (!result.Any()) return NoContent();


        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Person> Post([FromBody] Person pessoa)
    {
        try
        {
             _context.Pessoas.Add(pessoa);
             _context.SaveChanges();

        }
        catch (System.Exception)
        {
            
        return BadRequest(new {});
        }
       

        return Created("Criado", pessoa);
    }

    [HttpPut("{id}")]
    public ActionResult<Object> Update(
        [FromRoute] int id, 
        [FromBody] Person pessoa
        )
    {

        var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);
        if (result is null){
            return NotFound(new {
                msg = "Registro não encontrado",
                status = HttpStatusCode.NotFound
            });
        }

        try
        {
             _context.Pessoas.Update(pessoa);
             _context.SaveChanges(); 
        }
        catch (System.Exception)
        {
            return BadRequest(new{
                msg = "Houve erro ao enviar solicitação de atualização do id " + id,
                status = HttpStatusCode.OK 
            });
            
        }

      

        return Ok (new {
            msg = $"dados do id {id} atualizado",
            status = HttpStatusCode.OK
            });
        
    }

    [HttpDelete("{id}")]

    public ActionResult<Object> Delete(
        [FromRoute] int id
        )
    {
        var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);

        if (result is null)
        {
            return BadRequest(new
            {
                msg = "Conteúdo inexistente, solicitação inválida!",
                status = HttpStatusCode.BadRequest
            });
        }
        _context.Pessoas.Remove(result);
        _context.SaveChanges();

        return Ok(new
        {
            msg = "deletado pessoa de ID " + id,
            status = HttpStatusCode.OK
        });

    }


}

