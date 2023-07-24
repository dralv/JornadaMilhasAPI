using Dapper;
using JornadaMilhasAPI.Data.Interfaces;
using JornadaMilhasAPI.Dtos;
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
            _connectionString = _config["ConnectionString:JornadaMilhas"];
        }

        public async Task<int> AtualizarDepoimento(DepoimentoDto dto,int id)
        {
            var parameters = new
            {
                Id=id,
                Foto = dto.Foto,
                Depoimento = dto.DepoimentoTexto,
                Nome = dto.Nome
            };
            const string sql = "UPDATE DEPOIMENTOS SET FOTO=@Foto,DEPOIMENTO_TEXTO=@Depoimento,NOME=@Nome WHERE Id=@Id";
            using(var connection = new MySqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, parameters); 
            }
        }

        /// <summary>
        /// Método para fazer um insert no banco de dados
        /// </summary>
        /// <param name="depoimento"></param>
        /// <returns></returns>
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
            var parameters = new
            {
                id
            };
            const string sql = "DELETE FROM DEPOIMENTOS WHERE @Id=id";

            using(var connection = new MySqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, parameters);
            }
            
        }

        public async Task<Depoimento> ObterDepoimento(int id)
        {
            var parameters = new
            {
                id
            };

            const string sql = "SELECT * FROM DEPOIMENTOS WHERE Id=@id";

            using(var connection = new MySqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<Depoimento>(sql,parameters);
            }
        }

        public async Task<IEnumerable<Depoimento>> ObterDepoimentos(int qtdItens)
        {
            var parameters = new
            { 
                qtdItens
            };
            const string sql = "SELECT * FROM DEPOIMENTOS LIMIT @qtdItens";

            using(var connection = new MySqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Depoimento>(sql,parameters);
            }
        }
    }
}
