using Grpc.Core;
using Recommendations;
using server.services;

namespace server
{
    public class Program
    {
        const int Port = 5001;

        public static async Task Main(string[] args)
        {
            Server server = null;
            try
            {
                // Criação do servidor
                server = new Server
                {
                    Services = { RecommendationService.BindService(new RecommendationServiceImpl()) },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                };
                server.Start();

                Console.WriteLine($"Servidor GRPC ouvindo na porta {Port}");

                // Mantém o servidor rodando
                await Task.Delay(-1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao iniciar o servidor: {ex.Message}");
            }
            finally
            {
                // Garantir que o servidor será encerrado adequadamente em caso de erro
                if (server != null)
                {
                    await server.ShutdownAsync();
                    Console.WriteLine("Servidor GRPC encerrado com segurança.");
                }
            }
        }
    }
}
