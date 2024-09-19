using Grpc.Core;
using Recommendations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.services
{
    public class RecommendationServiceImpl : RecommendationService.RecommendationServiceBase
    {
        // Simulando lógica de recomendação
        List<Recommendation> recommendations = new List<Recommendation>
        {
            new Recommendation { ItemName = "Mad Max: Estrada da Fúria", Description = "Ação e aventura em um futuro pós-apocalíptico" },
            new Recommendation { ItemName = "Vingadores: Ultimato", Description = "Ação e ficção científica, com super-heróis lutando contra Thanos" },
            new Recommendation { ItemName = "Forrest Gump", Description = "Drama e comédia sobre a vida extraordinária de um homem simples" },
            new Recommendation { ItemName = "O Lobo de Wall Street", Description = "Comédia e drama, mostrando a ascensão e queda de um corretor da bolsa" },
            new Recommendation { ItemName = "Parasita", Description = "Suspense e drama sobre a diferença de classes sociais na Coreia do Sul" },
            new Recommendation { ItemName = "Coringa", Description = "Drama psicológico e suspense sobre a origem do icônico vilão" },
            new Recommendation { ItemName = "Pantera Negra", Description = "Ação e aventura, destacando a cultura africana e o super-herói Pantera Negra" },
            new Recommendation { ItemName = "A Origem", Description = "Ficção científica e suspense sobre a manipulação de sonhos e realidades" },
            new Recommendation { ItemName = "Matrix", Description = "Ficção científica e ação em um mundo controlado por máquinas" },
            new Recommendation { ItemName = "O Poderoso Chefão", Description = "Drama e crime sobre a vida de uma família mafiosa" },
            new Recommendation { ItemName = "Star Wars: O Império Contra-Ataca", Description = "Ficção científica e aventura na épica batalha espacial entre rebeldes e o império" },
            new Recommendation { ItemName = "Homem-Aranha: No Aranhaverso", Description = "Ação e animação, explorando o multiverso do Homem-Aranha" },
            new Recommendation { ItemName = "Titanic", Description = "Drama e romance, contando a história de amor durante a tragédia do Titanic" },
            new Recommendation { ItemName = "Jogos Vorazes", Description = "Ação e aventura em um futuro distópico onde jovens lutam até a morte" },
            new Recommendation { ItemName = "Clube da Luta", Description = "Suspense e drama, explorando temas de identidade e consumismo" },
            new Recommendation { ItemName = "O Grande Hotel Budapeste", Description = "Comédia e aventura em um hotel de luxo durante a era entre guerras" },
            new Recommendation { ItemName = "Shrek", Description = "Animação e comédia sobre um ogro que tenta recuperar sua tranquilidade" },
            new Recommendation { ItemName = "A Vida é Bela", Description = "Drama e comédia ambientada durante a Segunda Guerra Mundial, focando em um pai que protege seu filho do horror da guerra" },
            new Recommendation { ItemName = "Interestelar", Description = "Ficção científica e drama, abordando viagens espaciais e o futuro da humanidade" },
            new Recommendation { ItemName = "Pulp Fiction: Tempo de Violência", Description = "Crime e comédia, contando histórias interligadas de gangsters, boxeadores e criminosos" }
        };

        public override Task<RecommendationResponse> GetRecommendations(UserRequest request, ServerCallContext context)
        {
            // Filtra as recomendações com base nas preferências do usuário
            var filteredRecommendations = recommendations
                .Where(rec => request.Preferences.Any(p => rec.Description.Contains(p, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            // Cria a resposta com as recomendações filtradas
            var response = new RecommendationResponse();
            response.Recommendations.AddRange(filteredRecommendations);
            Console.WriteLine("Request received");

            return Task.FromResult(response);
        }
    }
}
