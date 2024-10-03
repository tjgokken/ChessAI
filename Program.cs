using ChessAI;
using ChessAI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System;

try
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
    builder.Services.AddScoped<StockfishService>();

    var host = builder.Build();

    // Configure global JS error handler after the app is built
    await ConfigureGlobalErrorHandler(host.Services);

    // Run the application
    await host.RunAsync();
}
catch (Exception ex)
{
    // Log the global error (in the browser console)
    Console.WriteLine($"Global error during initialization: {ex.Message}");

    throw; // Re-throw the exception so the app crashes if needed.
}

// Setup a global error handler for runtime errors using JSInterop
async Task ConfigureGlobalErrorHandler(IServiceProvider services)
{
    var jsRuntime = services.GetRequiredService<IJSRuntime>();

    try
    {
        // Call the JS function that adds the global error handler
        await jsRuntime.InvokeVoidAsync("addGlobalErrorHandler");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to configure JS error handler: {ex.Message}");
    }
}