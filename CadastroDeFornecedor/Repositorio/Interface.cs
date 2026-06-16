using Estagio.Controllers;
using Estagio.Models;

namespace Estagio.Repositorio
{
    public interface Interface
    {
        List<FornecedorModel> BuscarTodos();
        FornecedorModel Adiconar(FornecedorModel fornecedor);
        FornecedorModel ListarPorId(int id);
        FornecedorModel Atualizar(FornecedorModel fornecedor);
        bool Apagar(int id);
    }
}
