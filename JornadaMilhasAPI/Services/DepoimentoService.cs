using JornadaMilhasAPI.Data.Interfaces;
using JornadaMilhasAPI.Models;
using JornadaMilhasAPI.Services.Interfaces;

namespace JornadaMilhasAPI.Services
{
    public class DepoimentoService : IDepoimentoService
    {
        private readonly IDepoimentoRepository _repository;

        public DepoimentoService(IDepoimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AtualizarDepoimento(Depoimento depoimento)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CriarDepoimento(Depoimento depoimento)
        {
            return await _repository.CriarDepoimento(depoimento);
        }

        public async Task<int> DeletarDepoimento(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Depoimento> LerDepoimento(int id)
        {
            throw new NotImplementedException();
        }
    }
}
