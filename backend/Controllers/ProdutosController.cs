using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Data;
using backend.Dtos;

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

    [HttpPost]
    public async Task<ActionResult<Produto>> Criar(CriarProdutoDto dto){

        var produto = new Produto
        {
            Nome = dto.Nome,
            Preco = dto.Preco,
            QuantidadeEstoque = dto.QuantidadeEstoque,
            Ativo = true
        };
        contexto.Produtos.Add(produto);
        await contexto.SaveChangesAsync();
        return Ok(produto);
    }
    [HttpPut("{id}/estoque")]
    public async Task<ActionResult<Produto>> DefinirEstoque(int id, DefinirEstoqueDto dto){
        var produto = await contexto.Produtos.FindAsync(id);
        if (produto is null)
            return NotFound();
        
        produto.QuantidadeEstoque = dto.Quantidade;
        await contexto.SaveChangesAsync();
        return Ok(produto);
    }
}
