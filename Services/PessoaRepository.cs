using Lista4.Models;

namespace Lista4.Services
{
    public class PessoaRepository : IPessoaRepository
    {
        public static List<Pessoa> pessoas = [];

        public void AdicionarPessoa(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
        }

        public void AtualizarPessoa(Pessoa pessoa)
        {
            var pessoaAtualizada = pessoas.FirstOrDefault(p => p.Cpf == pessoa.Cpf);

            if (pessoaAtualizada is null)
                throw new Exception("Não existe nenhuma pessoa com esse CPF");

            pessoaAtualizada.Nome = pessoa.Nome;
            pessoaAtualizada.Peso = pessoa.Peso;
            pessoaAtualizada.Altura = pessoa.Altura;
        }

        public void RemoverPessoa(string cpf)
        {
            var pessoaRemover = pessoas.FirstOrDefault(p => p.Cpf == cpf);

            if (pessoaRemover is null)
                throw new Exception("Não há nenhuma pessoa cadastrada com esse CPF");

            pessoas.Remove(pessoaRemover);
        }

        public List<Pessoa> GetPessoas()
        {
            return pessoas;
        }

        public Pessoa? GetByCpf(string cpf)
        {
            var pessoaPesquisada = pessoas.FirstOrDefault(p => p.Cpf == cpf);

            return pessoaPesquisada;
        }

        public List<Pessoa> GetByImc()
        {
            var listaImcBom = new List<Pessoa>();

            foreach (var pessoa in pessoas)
            {
                var imc = pessoa.Peso / (pessoa.Altura * pessoa.Altura);

                if (imc >= 18 && imc <= 24)
                    listaImcBom.Add(pessoa);
            }

            return listaImcBom;
        }

        public Pessoa? GetByNome(string nome)
        {
            var pessoaPesquisada = pessoas.FirstOrDefault(p => p.Nome == nome);

            return pessoaPesquisada;
        }
    }
}
