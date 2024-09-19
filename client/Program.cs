using Grpc.Net.Client;
using Recommendations;

namespace client
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Cria o canal de comunicação com o servidor
            using var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var client = new RecommendationService.RecommendationServiceClient(channel);

            // Define o pedido de recomendações com preferências do usuário
            var request = new UserRequest
            {
                UserId = "123",
                Preferences = { "ação", "comédia" }
            };

            // Envia a requisição e recebe as recomendações
            var response = await client.GetRecommendationsAsync(request);

            // Itera sobre as recomendações recebidas
            foreach (var recommendation in response.Recommendations)
            {
                Console.WriteLine($"Recomendado: {recommendation.ItemName} - {recommendation.Description}");
            }
        }
    }
}
