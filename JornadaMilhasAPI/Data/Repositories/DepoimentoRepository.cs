using Dapper;
using JornadaMilhasAPI.Data.Interfaces;
using JornadaMilhasAPI.Models;
using MySqlConnector;
using System.Runtime.CompilerServices;

namespace JornadaMilhasAPI.Data.Repositories
{
    public class DepoimentoRepository : IDepoimentoRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public DepoimentoRepository(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("JornadaMilhas");
        }

        public async Task<int> AtualizarDepoimento(Depoimento depoimento)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CriarDepoimento(Depoimento depoimento)
        {
            var parameters = new
            {
                depoimento.Foto,
                depoimento.DepoimentoTexto,
                depoimento.Nome
            };
            const string sql = "INSERT INTO DEPOIMENTOS(FOTO,DEPOIMENTO_TEXTO,NOME) VALUES(@Foto,@DepoimentoTexto,@Nome)";

            using(var connection = new MySqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql,parameters);
            }
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
