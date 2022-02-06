// The following code creates a WebApplicationBuilder and a WebApplication with preconfigured defaults.
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// The following code creates an HTTP GET endpoint / which returns Hello, World!
app.MapGet("/", () => "Hello, World!");

app.MapGet("/morsecode", () =>
{
    return Morsecode.morsecode;
});

app.MapGet("/morsecode/{id}", (int id) =>
{
    return Morsecode.GetFirstLetter(id);
});

app.MapPost("/morsecode", (Data data) =>
{
    return Morsecode.morsecode.Append(data.Name);

});

// The following code runs the app.
app.Run();


Dictionary<string, string> morsecodeDictionary = new Dictionary<string, string>()
{
    { "A", "1" },
    { "B", "2" },
    { "C", "3" },
};


public class Morsecode
{
    public static string[] morsecode = { "A", "B", "C" };
    public static string GetFirstLetter(int id)
    {
        if (morsecode is not null && id <= morsecode.Length - 1)
        {
            return (string)morsecode.GetValue(id);
        }
        else
        {
            return "Array must be null || id is oustide array.Length.";
        }
    }
}

class Data
{
    public int Id { get; set; }
    public string? Name { get; set; }
}