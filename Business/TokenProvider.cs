using System.Threading.Tasks;
using BasketApiClient.Models;

public class TokenProvider
{
    private readonly TokenService _tokenService;
    private string _token;

    public TokenProvider(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public async Task<string> GetTokenAsync()
    {
        if (string.IsNullOrEmpty(_token))
        {
            _token = await _tokenService.GetTokenAsync();
        }

        return _token;
    }

    public void SetToken(string token)
    {
        _token = token;
    }
}