using JornadaMilhasAPI.Models;

namespace JornadaMilhasAPI.Data.Interfaces
{
    public interface IDepoimentoRepository
    {
         Task<int> CriarDepoimento(Depoimento depoimento);
         Task<Depoimento> LerDepoimento(int id);
         Task<int> AtualizarDepoimento(Depoimento depoimento);
         Task<int> DeletarDepoimento(int id);
    }
}
