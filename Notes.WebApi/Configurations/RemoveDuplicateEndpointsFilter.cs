using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.RegularExpressions;

namespace Notes.WebApi.Configurations;

public partial class RemoveDuplicateEndpointsDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var regex = TitleVersionApi();
        var pathsToRemove = swaggerDoc.Paths
            .Where(p => !regex.IsMatch(p.Key))
            .Select(p => p.Key)
            .ToList();

        foreach (var path in pathsToRemove)
        {
            swaggerDoc.Paths.Remove(path);
        }
    }

    [GeneratedRegex(@"^/api/v\d+/[^/]+(/[^/]+)*$")]
    private static partial Regex TitleVersionApi();
}