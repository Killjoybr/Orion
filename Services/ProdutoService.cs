using csharp.Models;

namespace csharp.Services;

public static class ProdutoService {
    private static List<Produto> Produtos { get; }
    private static int id = 1;
    
    public static List<Produto> GetAll() => Produtos;

    public static Produto? Get(int id) => Produtos.FirstOrDefault(predicate => predicate.Id == id);

    public static void Add(Produto produto){
        produto.Id = id++;
        Produtos.Add(produto);
    }

    public static void Delete(int id){
        var produtoEncontrado = Get(id);
        if (produtoEncontrado is null){
            return;
        }
        Produtos.Remove(produtoEncontrado);
    }

    public static void Update(Produto produto){
        var indice = Produtos.FindIndex(predicate => predicate.Id == produto.Id);
        if (indice == -1){
            return;
        }

        Produtos[indice] = produto;
    }

}