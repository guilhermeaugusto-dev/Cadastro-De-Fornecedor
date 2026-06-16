using Estagio.Data;
using Estagio.Models;
using Estagio.Repositorio;

namespace Estagio.Servicos
{
    public class FornecedoresRepositorio : Interface

    {
        private readonly BancoContext _bancoContext;
        public FornecedoresRepositorio (BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public FornecedorModel Adiconar(FornecedorModel fornecedor)
        {
           _bancoContext.Fornecedores.Add(fornecedor);
              _bancoContext.SaveChanges();
            return fornecedor;
        }

        public bool Apagar(int id)
        {
            FornecedorModel fornecedorDb = ListarPorId(id);
            if (fornecedorDb == null) throw new SystemException("Houve um error na deletação do contato");
            _bancoContext.Fornecedores.Remove(fornecedorDb);
            _bancoContext.SaveChanges();
            return true;

        }

        public FornecedorModel Atualizar(FornecedorModel fornecedor)
        {
            FornecedorModel fornecedorDb = ListarPorId(fornecedor.Id);
            if (fornecedorDb == null) throw new SystemException("Houve um error ");
            fornecedorDb.Nome = fornecedor.Nome;
            fornecedorDb.CNPJ = fornecedor.CNPJ;
            fornecedorDb.Segmento = fornecedor.Segmento;
            fornecedorDb.CEP = fornecedor.CEP;
            fornecedorDb.Endereco = fornecedor.Endereco;

            _bancoContext.Fornecedores.Update(fornecedorDb);
            _bancoContext.SaveChanges();
            return fornecedorDb;

        }

        public List<FornecedorModel> BuscarTodos()
        {
            return _bancoContext.Fornecedores.ToList();
        }

        public FornecedorModel ListarPorId(int id)
        {
            return _bancoContext.Fornecedores.FirstOrDefault(x => x.Id == id );
        }
    }
}
