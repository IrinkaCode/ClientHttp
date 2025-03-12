using System.ComponentModel;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
HttpClient httpClient = new HttpClient();

Client client = new Client()
{
City = "пвап",
Firstname = "вппавпва",
Surname = "рапрп",
Lastname = "апрапр",
Company = "парпар",
Phone = "67-67-56"
};

Task<List<Client>> task = getClients();
List<Client> clients = task.Result;

foreach (Client c in clients)
{
Console.WriteLine(c.Firstname + " " + c.Lastname);
}

async Task<List<Client>> getClients()
{
StringContent content = new StringContent("getClients");
using var request = new HttpRequestMessage(HttpMethod.Get, "http://127.0.0.1:8888/connection/");
request.Headers.Add("table", "client");
request.Content = content;
using HttpResponseMessage response = await httpClient.SendAsync(request);
string responseText = await response.Content.ReadAsStringAsync();
List<Client> clients = JsonSerializer.Deserialize<List<Client>>(responseText)!;
return clients;
}

async void SendClient(Client client)
{
JsonContent content = JsonContent.Create(client);
content.Headers.Add("table", "client");
using var response = await httpClient.PostAsync("http://127.0.0.1:8888/connection/", content);
string responseText = await response.Content.ReadAsStringAsync();
Console.WriteLine(responseText);
}

class Client
{
    [JsonPropertyName("clientid")]
    public int Clientid { get; set; }
    [JsonPropertyName("firstname")]
    public string Firstname { get; set; } = null!;
    [JsonPropertyName("surname")]
    public string? Surname { get; set; }
    [JsonPropertyName("lastname")]
    public string Lastname { get; set; } = null!;
    [JsonPropertyName("company")]
    public string Company { get; set; } = null!;
    [JsonPropertyName("phone")]
    public string Phone { get; set; } = null!;
    [JsonPropertyName("city")]
    public string City { get; set; } = null!;
}