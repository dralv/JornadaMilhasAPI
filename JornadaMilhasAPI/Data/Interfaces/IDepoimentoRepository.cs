using JornadaMilhasAPI.Dtos;
using JornadaMilhasAPI.Models;

namespace JornadaMilhasAPI.Data.Interfaces
{
    public interface IDepoimentoRepository
    {
         Task<int> CriarDepoimento(Depoimento depoimento);
         Task<Depoimento>ObterDepoimento(int id);
         Task<int> AtualizarDepoimento(DepoimentoDto dto,int id);
         Task<int> DeletarDepoimento(int id);
         Task<IEnumerable<Depoimento>> ObterDepoimentos(int qtdItens);
    }
}
