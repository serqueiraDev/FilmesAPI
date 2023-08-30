using FilmesAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("v1/Filmes")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 1;
    
    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperarFilmes()
    {
        return filmes;
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarFilmePorId(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
            return NotFound();
        return Ok(filme);
    }

    [HttpGet("{skip}/{take}")]
    public IEnumerable<Filme> RecuperarFilmesPaginado(int skip, int take)
    {
        return filmes.Skip(skip).Take(take);
    }
}
