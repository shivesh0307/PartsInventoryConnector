using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models.ExternalConnectors;
using Microsoft.Kiota.Authentication.Azure;
namespace PartsInventoryConnector.Graph;

public static class GraphHelper
{
    private static GraphServiceClient? graphClient;
    private static HttpClient? httpClient;
    public static void Initialize(Settings settings)
    {
        // Create a credential that uses the client credentials
        // authorization flow
        var credential = new ClientSecretCredential(
            settings.TenantId, settings.ClientId, settings.ClientSecret);

        // Create an HTTP client
        httpClient = GraphClientFactory.Create();

        // Create an auth provider
        var authProvider = new AzureIdentityAuthenticationProvider(
            credential, scopes: new[] { "https://graph.microsoft.com/.default" });

        // Create a Graph client using the credential
        graphClient = new GraphServiceClient(httpClient, authProvider);
    }
}