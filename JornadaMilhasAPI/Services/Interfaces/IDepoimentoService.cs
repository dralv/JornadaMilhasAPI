using JornadaMilhasAPI.Models;
using JornadaMilhasAPI.Dtos;

namespace JornadaMilhasAPI.Services.Interfaces
{
    public interface IDepoimentoService
    {
        Task<int> CriarDepoimento(DepoimentoDto dto);
        Task<Depoimento> ObterDepoimento(int id);
        Task<int> AtualizarDepoimento(DepoimentoDto dto,int id);
        Task<int> DeletarDepoimento(int id);
        Task<IEnumerable<Depoimento>> ObterDepoimentos(int qtdItens);
    }
}
