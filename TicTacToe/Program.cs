using System.Net.Http.Json;
using System.Text.RegularExpressions;

namespace TicTacToe;

class Program
{
    // docker run -d --rm -ti -p 8080:8080 utrescu/tictactoeapi:latest
    // http://localhost:8080/swagger/index.html 
    static async Task Main(string[] args)
    {
        var url = "http://localhost:8080/";
        var uri = new Uri(url);

        using HttpClient client = new()
        {
            BaseAddress = uri
        };
       var partida = client.GetFromJsonAsync<Partida>("partida/");
        //Jugadors com una string 
        var response_participants = await client.GetStringAsync("jugadors");
        // Patro per participants
        var pattern = @"participant ([A-Z][a-z]+ [A-Z]\w[a-z]+).*representa( a|nt de )";
        // Regex per participants
        var regex = new Regex(pattern);
        var matches = regex.Matches(response_participants);
        /* Regex Values
         foreach (int lineas in response_participants)
        {
            var Nom = matches[lineas].Groups[1].Value;
            var Pais = matches[lineas].Groups[2].Value;
        }*/
        /* //Classe amb metode
        // LlistarJugadors();
        // Partida.Resultat();
        // Resultat.Campio();
        */
    }
}