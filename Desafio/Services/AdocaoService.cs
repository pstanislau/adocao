using Desafio.Domain.DTO;
using Desafio.Domain.Entity;
using Desafio.Services.Base;

namespace Desafio.Services;

public class AdocaoService
    {
        private static List<Adocao> listaDeAnimais; 
        private static int proximoId = 1;

        public AdocaoService()
        {

            if (listaDeAnimais == null)
            {
                listaDeAnimais = new List<Adocao>();
                listaDeAnimais.Add(new Adocao()
                {
                    IdAdocao = proximoId++,
                    Nome = "Cãozinho",
                    Idade = 4,
                    Especie = "Cachorro",
                    Nascimento= new DateTime(2018, 5, 31),
                    Fofura = 3,
                    Carinho= 5,
                    Email ="tomacheski18@gmail.com"
                });
                listaDeAnimais.Add(new Adocao()
                {
                    IdAdocao = proximoId++,
                    Nome = "Celo",
                    Idade = 4,
                    Especie = "Capivara",
                    Nascimento = new DateTime(2018, 5, 31),
                    Fofura = 5,
                    Carinho = 2,
                    Email = "tomacheski18@gmail.com"
                });
            }
        }

        public ServiceResponse<Adocao> CadastrarNovo(AdocaoCreateRequest model)
        {
            if (!model.Nascimento.HasValue || model.Nascimento < new DateTime(2000, 1, 1))
            {
                return new ServiceResponse<Adocao>("Somente é possível cadastrar animais com até 22 anos");
            }

            var novaAdocao = new Adocao()
            {
                IdAdocao = proximoId++,
                Nome = model.Nome,
                Idade = model.Idade,
                Especie = model.Especie,
                Nascimento = model.Nascimento,
                Fofura = model.Fofura,  
                Carinho = model.Carinho,
                Email = model.Email
            };

            listaDeAnimais.Add(novaAdocao);

            return new ServiceResponse<Adocao>(novaAdocao);
        }

        public List<Adocao> ListarTodos()
        {
            return listaDeAnimais;
        }

        public ServiceResponse<Adocao> PesquisarPorId(int id)
        {
            var resultado = listaDeAnimais.Where(x => x.IdAdocao == id).FirstOrDefault();
            if (resultado == null)
                return new ServiceResponse<Adocao>("Não encontrado!");
            else
                return new ServiceResponse<Adocao>(resultado);
        }

        public ServiceResponse<Adocao> PesquisarPorNome(string nome)
        {

            var resultado = listaDeAnimais.Where(x => x.Nome == nome).FirstOrDefault();
            if (resultado == null)
                return new ServiceResponse<Adocao>("Não encontrado!");
            else
                return new ServiceResponse<Adocao>(resultado);
        }

        public ServiceResponse<Adocao> Editar(int id, AdocaoUpdateRequest model)
        {
            var resultado = listaDeAnimais.Where(x => x.IdAdocao == id).FirstOrDefault();

            if (resultado == null)
                return new ServiceResponse<Adocao>("Animal não encontrado!");

            resultado.Idade = model.Idade;

            return new ServiceResponse<Adocao>(resultado);
        }

        public ServiceResponse<bool> Deletar(int id)
        {
            var resultado = listaDeAnimais.Where(x => x.IdAdocao == id).FirstOrDefault();

            if (resultado == null)
                return new ServiceResponse<bool>("Animal não encontrado!");

            listaDeAnimais.Remove(resultado);

            return new ServiceResponse<bool>(true);
        }
    }