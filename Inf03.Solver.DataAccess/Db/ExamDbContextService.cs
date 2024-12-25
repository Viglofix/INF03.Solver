using Inf03.Solver.DataAccess.Model;
using System.Text.Json;
using System.Reflection;

namespace Inf03.Solver.DataAccess.Db;
public class ExamDbContextService
{
    private const int endIndexDistance = 7;
    private const int startIndex = 0;
    private const string endIndexOf = @"Solver\";
    public async Task<string> JsonConnectionStringDeserialize()
    {
        var path = Environment.CurrentDirectory;
        var trimedPath = path.Substring(startIndex, path.IndexOf(endIndexOf)+endIndexDistance - startIndex)+ "Inf03.Solver.DataAccess\\JsonFiles\\ConnectionString.js";
        using var reader = new FileStream(trimedPath,FileMode.Open,FileAccess.Read);
        var connectionString = await JsonSerializer.DeserializeAsync<ConnectionStringRootModel>(reader);
        return connectionString?.ConnectionStringModel.Db1 ?? string.Empty;
    }
}
