using System.Text;
using System.Text.Json;
using BasketApiClient.Models;

public class TokenService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<TokenService> _logger;

    public TokenService(HttpClient httpClient, IConfiguration configuration, ILogger<TokenService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<string> GetTokenAsync()
    {
        // Get the email from the configuration
        var email = _configuration["Authentication:Email"];
        var requestBody = new { email = email };
        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

        // Log the request
        _logger.LogInformation("Requesting token with email: {Email}", email);

        // Send the request
        var response = await _httpClient.PostAsync("https://azfun-impact-code-challenge-api.azurewebsites.net/api/Login", content);
        if (!response.IsSuccessStatusCode)
        {
            // Log the error
            _logger.LogError("Failed to get token. Status Code: {StatusCode}, Response: {Response}", response.StatusCode, await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();
        }

        // Log the response
        var responseContent = await response.Content.ReadAsStringAsync();
        _logger.LogInformation("Token response: {ResponseContent}", responseContent);

        // Deserialize the response
        var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseContent);

        // Return the token
        return tokenResponse.Token;
    }
}