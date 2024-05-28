using System.Net.Http.Headers;

public class AuthenticatedHttpClientHandler : DelegatingHandler
{
    private readonly TokenProvider _tokenProvider;

    public AuthenticatedHttpClientHandler(TokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Get the token from the TokenProvider
        // This is an async operation and commented out during testing
        // var token = await _tokenProvider.GetTokenAsync();

        // Hardcoded token for testing purposes
        // Security breach using hardcoded token
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJrZXlhbmphdmFuc2hpckBsaXZlLmRrIiwiZXhwIjoxNzE2ODk0MjA4LCJpc3MiOiJJTVBBQ1QuQ29kZUNoYWxsZW5nZSIsImF1ZCI6IklNUEFDVC5Db2RlQ2hhbGxlbmdlIn0.M-Ex-AxfXlSTPRfwbOWfGM-9Pk5puqvYZC-28y--NiY";

        // Add the token to the request
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        // Call the base SendAsync method
        return await base.SendAsync(request, cancellationToken);
    }
}
