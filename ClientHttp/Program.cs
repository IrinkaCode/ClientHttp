using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json;
HttpClient httpClient = new HttpClient();
async void AddClient(Client client)
{
    JsonContent content = JsonContent.Create(client);
    content.Headers.Add("table", "client");
    using var response = await httpClient.PostAsync("http://127.0.0.1:8888/connection/", content);
    string responseText = await response.Content.ReadAsStringAsync();
    Console.WriteLine(responseText);
}
async Task<string> getClients()
{
    StringContent content = new StringContent("allClients");
    using var request = new HttpRequestMessage(HttpMethod.Get, "http://127.0.0.1:8888/connection/");
    request.Content = content;
    using var response = await httpClient.SendAsync(request);
    string text = await response.Content.ReadAsStringAsync();
    return text;
}

Client client = new Client()
{
    City = "пвап",
    Firstname = "вппавпва",
    Surname = "рапрп",
    Lastname = "апрапр",
    Company = "парпар",
    Phone = "67-67-56"
};
Task<string> res = getClients();
Console.WriteLine(res.Result);


class Client
{
    public int Clientid { get; set; }
    public string Firstname { get; set; } = null!;
    public string? Surname { get; set; }
    public string Lastname { get; set; } = null!;
    public string Company { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string City { get; set; } = null!;
}