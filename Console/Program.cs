
using Microsoft.Extensions.DependencyInjection;
using PlatformServices.PlatformServiceDescriptors;
using System.Text;

var serviceCollection = new ServiceCollection();
serviceCollection.AddPlatformServiceDescriptors();

var serviceProvider = serviceCollection.BuildServiceProvider();
var stringBuilder = new StringBuilder();

var resolver = serviceProvider.GetRequiredService<IPlatformServiceDescriptorsResolver>();
foreach (var descriptor in resolver.ResolveAllDescriptors())
{
    stringBuilder.AppendLine($"Service Descriptor: {descriptor.PlatformServiceIdentifier}");

    foreach (var operation in descriptor.Operations)
    {
        var inputType = operation.InputType?.Name ?? "N/A";
        var outputType = operation.OutputType.FullName;

        stringBuilder.AppendLine(
            $"\tOperation: {operation.PlatformOperationIdentifier}; Input Type: {inputType}; Output Type: {outputType}");
    }

    stringBuilder.AppendLine();
}

System.Console.WriteLine(stringBuilder);
