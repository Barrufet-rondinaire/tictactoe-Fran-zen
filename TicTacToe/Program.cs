using System.Net.Http.Json;

namespace TicTacToe;

class Program
{
    // docker run -d --rm -ti -p 8080:8080 utrescu/tictactoeapi:latest
    // http://localhost:8080/swagger/index.html 
    static async Task Main(string[] args)
    {
        var url = "http://localhost:8080/swagger/index.html";
        var uri = new Uri(url);

        using HttpClient client = new()
        {
            BaseAddress = uri
        };
        var response_partida = client.GetAsync("partida");
        var response_participants = await client.GetFromJsonAsync<Partida>("participants");
        var pattern = @"participant ([A-Z][a-z]+ [A-Z]\w[a-z]+).*representa( a|nt de )";
        // LlistarJugadors();
        // Partida.Resultat();
        // Resultat.Campio();
        
    }
}