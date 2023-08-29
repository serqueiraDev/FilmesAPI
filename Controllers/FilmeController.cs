using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("v1/Filmes")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 1;
    
    [HttpPost]
    public void AdicionarFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperarFilmes()
    {
        return filmes;
    }

    [HttpGet("{id}")]
    public Filme? RecuperarFilmePorId(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
    }

    [HttpGet("{skip}/{take}")]
    public IEnumerable<Filme> RecuperarFilmesPaginado(int skip, int take)
    {
        return filmes.Skip(skip).Take(take);
    }
}
