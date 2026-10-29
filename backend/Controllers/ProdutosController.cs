using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Data;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController(CantinaDbContext contexto) : ControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<Produto>>> Listar(){
        var produtos = await contexto.Produtos.ToListAsync();
        return Ok(produtos);
    }
}
