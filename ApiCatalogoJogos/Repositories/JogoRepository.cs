using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            { Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"), new Jogo{ Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"), Nome = "Fifa 21", Produtora = "EA", Preco = 200 } },
            { Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"), new Jogo{ Id = Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"), Nome = "Fifa 20", Produtora = "EA", Preco = 190 } },
            { Guid.Parse("3da2af12-290a-4203-9109-91718151ca68"), new Jogo{ Id = Guid.Parse("3da2af12-290a-4203-9109-91718151ca68"), Nome = "Fifa 19", Produtora = "EA", Preco = 180 } },
            { Guid.Parse("0c55bb9f-9757-4f8c-b69d-ff3f3856b4fd"), new Jogo{ Id = Guid.Parse("0c55bb9f-9757-4f8c-b69d-ff3f3856b4fd"), Nome = "Fifa 18", Produtora = "EA", Preco = 150 } },
            { Guid.Parse("4ce4ace5-024c-475e-bb3d-e72d81109c80"), new Jogo{ Id = Guid.Parse("4ce4ace5-024c-475e-bb3d-e72d81109c80"), Nome = "Street Fighter II", Produtora = "Capcom", Preco = 80 } },
            { Guid.Parse("c3ef1964-ecd2-409f-a424-de4fb9a96b3f"), new Jogo{ Id = Guid.Parse("c3ef1964-ecd2-409f-a424-de4fb9a96b3f"), Nome = "Grand Theft Auto V", Produtora = "Rockstar", Preco = 120 } }
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }
           
        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {

        }
    }
}
