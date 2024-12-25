using System.Text.Json.Serialization;

namespace Inf03.Solver.DataAccess.Model;
    public class ConnectionStringRootModel
    {
        [JsonPropertyName("ConnectionString")]
        public required ConnectionStringModel ConnectionStringModel { get; set; }
    }
