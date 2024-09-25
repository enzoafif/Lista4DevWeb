using Lista4.Models;

namespace Lista4.Services
{
    public interface IPessoaRepository
    {
        void AdicionarPessoa(Pessoa pessoa);
        void AtualizarPessoa(Pessoa pessoa);
        void RemoverPessoa(string cpf);
        List<Pessoa> GetPessoas();
        Pessoa? GetByCpf(string cpf);
        List<Pessoa> GetByImc();
        Pessoa? GetByNome(string nome);
    }
}
