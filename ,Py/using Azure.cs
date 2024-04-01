using Azure.Identity;
using Microsoft.Kiota.Authentication.Azure;
using Microsoft.Kiota.Http.HttpClientLibrary;
using MyTaskApp.Client;

class Program
{
    static async Task Main(string[] args)
    {
        // The auth provider will only authorize requests to
        // the allowed hosts, in this case Microsoft Graph
        var allowedHosts = new [] { "graph.microsoft.com" };
        var graphScopes = new [] { "User.Read" };

        var credential = new DeviceCodeCredential();
        var authProvider = new AzureIdentityAuthenticationProvider(credential, allowedHosts, scopes: graphScopes);
        var adapter = new HttpClientRequestAdapter(authProvider);
        /// <summary>
        /// Represents a client for handling tasks.
        /// </summary>
        var taskClient = new TaskClient(adapter);

        var taskLists = await taskClient.Me.Todo.Lists.GetAsync();
    }
}