using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using Microsoft.Graph.Models.ExternalConnectors;
using Microsoft.Graph.Models.ODataErrors;
using PartsInventoryConnector;
using PartsInventoryConnector.Data;
using PartsInventoryConnector.Graph;

Console.WriteLine("Parts Inventory Search Connector\n");

var settings = Settings.LoadSettings();

// Initialize Graph
InitializeGraph(settings);

ExternalConnection? currentConnection = null;
int choice = -1;

while (choice != 0)
{
    Console.WriteLine($"Current connection: {(currentConnection == null ? "NONE" : currentConnection.Name)}\n");
    Console.WriteLine("Please choose one of the following options:");
    Console.WriteLine("0. Exit");
    Console.WriteLine("1. Create a connection");
    Console.WriteLine("2. Select an existing connection");
    Console.WriteLine("3. Delete current connection");
    Console.WriteLine("4. Register schema for current connection");
    Console.WriteLine("5. View schema for current connection");
    Console.WriteLine("6. Push updated items to current connection");
    Console.WriteLine("7. Push ALL items to current connection");
    Console.Write("Selection: ");

    try
    {
        choice = int.Parse(Console.ReadLine() ?? string.Empty);
    }
    catch (FormatException)
    {
        // Set to invalid value
        choice = -1;
    }

    switch (choice)
    {
        case 0:
            // Exit the program
            Console.WriteLine("Goodbye...");
            break;
        case 1:
            currentConnection = await CreateConnectionAsync();
            break;
        case 2:
            currentConnection = await SelectExistingConnectionAsync();
            break;
        case 3:
            await DeleteCurrentConnectionAsync(currentConnection);
            currentConnection = null;
            break;
        case 4:
            await RegisterSchemaAsync();
            break;
        case 5:
            await GetSchemaAsync();
            break;
        case 6:
            await UpdateItemsFromDatabaseAsync(true, settings.TenantId);
            break;
        case 7:
            await UpdateItemsFromDatabaseAsync(false, settings.TenantId);
            break;
        default:
            Console.WriteLine("Invalid choice! Please try again.");
            break;
    }
}

static string? PromptForInput(string prompt, bool valueRequired)
{
    string? response;

    do
    {
        Console.WriteLine($"{prompt}:");
        response = Console.ReadLine();
        if (valueRequired && string.IsNullOrEmpty(response))
        {
            Console.WriteLine("You must provide a value");
        }
    } while (valueRequired && string.IsNullOrEmpty(response));

    return response;
}

static DateTime GetLastUploadTime()
{
    if (File.Exists("lastuploadtime.bin"))
    {
        return DateTime.Parse(
            File.ReadAllText("lastuploadtime.bin")).ToUniversalTime();
    }

    return DateTime.MinValue;
}

static void SaveLastUploadTime(DateTime uploadTime)
{
    File.WriteAllText("lastuploadtime.bin", uploadTime.ToString("u"));
}


void InitializeGraph(Settings settings)
{
    // TODO
}

async Task<ExternalConnection?> CreateConnectionAsync()
{
    // TODO
    throw new NotImplementedException();
}

async Task<ExternalConnection?> SelectExistingConnectionAsync()
{
    // TODO
    throw new NotImplementedException();
}

async Task DeleteCurrentConnectionAsync(ExternalConnection? connection)
{
    // TODO
}

async Task RegisterSchemaAsync()
{
    // TODO
}

async Task GetSchemaAsync()
{
    // TODO
}

async Task UpdateItemsFromDatabaseAsync(bool uploadModifiedOnly, string? tenantId)
{
    // TODO
}