using JornadaMilhasAPI.Models;

namespace JornadaMilhasAPI.Services.Interfaces
{
    public interface IDepoimentoService
    {
        Task<int> CriarDepoimento(Depoimento depoimento);
        Task<Depoimento> ObterDepoimento(int id);
        Task<int> AtualizarDepoimento(Depoimento depoimento);
        Task<int> DeletarDepoimento(int id);
        Task<IEnumerable<Depoimento>> ObterDepoimentos(int qtdItens);
    }
}
