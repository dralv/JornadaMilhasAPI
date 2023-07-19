using AutoMapper;
using JornadaMilhasAPI.Data.Interfaces;
using JornadaMilhasAPI.Models;
using JornadaMilhasAPI.Services.Interfaces;

namespace JornadaMilhasAPI.Services
{
    public class DepoimentoService : IDepoimentoService
    {
        private readonly IDepoimentoRepository _repository;
        private readonly IMapper _mapper;

        public DepoimentoService(IDepoimentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        public async Task<Depoimento> ObterDepoimento(int id)
        {
            return await _repository.ObterDepoimento(id);
        }

        public async Task<IEnumerable<Depoimento>> ObterDepoimentos(int qtdItens)
        {
            return await _repository.ObterDepoimentos(qtdItens);
        }
    }
}
