using csharp.Models;
using csharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace csharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase{
    public ProdutoController(){
        
    }

    [HttpGet]
    public ActionResult<List<Produto>> GetAll() => ProdutoService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Produto> Get(int id){
        var produto = ProdutoService.Get(id);
        if (produto is null){
            return NotFound();
        }

        return produto;
    }

    [HttpPost]
    public IActionResult Create(Produto produto){
        ProdutoService.Add(produto);
        
        return CreatedAtAction(nameof(Get), new { id = produto.Id, produto});
    }

    [HttpPut]
    public IActionResult Update(int id, Produto produto){
        if (id != produto.Id){
            return BadRequest();
        }

        var produtoEncontrado = ProdutoService.Get(id);
        if (produtoEncontrado is null){
            return NotFound();
        }

        ProdutoService.Update(produto);

        return NoContent();
    }
}
    