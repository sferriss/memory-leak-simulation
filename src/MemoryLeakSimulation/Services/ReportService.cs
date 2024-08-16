using System.Text;

namespace MemoryLeakSimulation.Services;

public static class ReportService
{
    private static readonly Dictionary<Guid, string> Results = new();

    public static Guid Generate()
    {
        var requestId = Guid.NewGuid();

        Task.Run(() =>
        {
            var sb = new StringBuilder();
            for (var i = 0; i < 5000; i++)
            {
                var dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                sb.Append($"This is a test: {dateTime}");
            }

            Results.Add(requestId, sb.ToString());
            SaveResult(requestId, sb.ToString());

        });

        return requestId;
    }
    private static void SaveResult(Guid requestId, string result)
    {
        
    }
}