using System.Text.Json;

namespace AlexSuperUserManager.Scripts;

public class Configurator
{
    public string GetConnectionString()
    {
        string json = File.ReadAllText("appsettings.json");
        JsonDocument appSettings = JsonDocument.Parse(
            json, new JsonDocumentOptions {CommentHandling = JsonCommentHandling.Skip});
        return appSettings.RootElement.GetProperty("ConnectionStrings").GetProperty("DefaultConnection").GetString();
    }
}