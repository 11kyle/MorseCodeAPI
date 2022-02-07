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
    char[] letters = data.Name.ToCharArray();
    List<string> convertedLetters = new List<string>();
    
    foreach (char letter in letters)
    {
        char c = char.ToUpper(letter);
        string convertedLetter = Morsecode.morsecodeDictionary[c];
        convertedLetters.Add(convertedLetter);
    }
    string convertedString = String.Join("", convertedLetters);
    return convertedString;
});

// The following code runs the app.
app.Run();


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

    public static Dictionary<char, string> morsecodeDictionary = new Dictionary<char, string>()
    {
        { 'A', ".-" },
        { 'B', "-..." },
        { 'C', "-.-." },
        { 'D', "-.." },
        { 'E', "." },
        { 'F', "..-." },
        { 'G', "--." },
        { 'H', "...." },
        { 'I', ".." },
        { 'J', ".---" },
        { 'K', "-.-" },
        { 'L', ".-.." },
        { 'M', "--" },
        { 'N', "-." },
        { 'O', "---" },
        { 'P', ".--." },
        { 'Q', "--.-" },
        { 'R', ".-." },
        { 'S', "..." },
        { 'T', "-" },
        { 'U', "..-" },
        { 'V', "...-" },
        { 'W', ".--" },
        { 'X', "-..-" },
        { 'Y', "-.--" },
        { 'Z', "--.." },
        { ' ', "/" },
        { '.', ".-.-.-" },
        { '?', "..--.." },
        { '!', "-.-.--" }
    };
}

class Data
{
    public int Id { get; set; }
    public string? Name { get; set; }
}