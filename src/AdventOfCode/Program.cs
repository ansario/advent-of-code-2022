using AdventOfCode;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//setup our DI
var serviceCollection = new ServiceCollection();

serviceCollection.AddTransient<IPuzzle, Day1>();
serviceCollection.AddHttpClient<IAdventClient, AdventClient>();

var serviceProvider = serviceCollection
    .AddLogging()
    .BuildServiceProvider();

Console.WriteLine(await serviceProvider.GetService<IPuzzle>().ExecuteAsync());
        


// await host.RunAsync();

