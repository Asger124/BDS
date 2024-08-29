
string author;
DateTimeOffset timestamp;
string Message;
string TimeForm = "MM'/'dd'/'yy HH:mm:ss";

if (args[0] == "read")
{
    read();
}

void read()
{
    // Open the text file using a stream reader.
    using StreamReader reader = new("chirp_cli_db.csv");

    // Read the stream as a string.
    string text = reader.ReadToEnd();

    // Split Data on newline
    string[] build = text.Split('\n');


    for (int i = 1; i < build.Length - 1; i++)
    {
        // Split data again on quotes " 
        string[] splitquote = build[i].Split('"');

        // Assign variables and remove commas 
        author = splitquote[0].TrimEnd(',');
        Message = splitquote[1];
        string time_trimmed = splitquote[2].TrimStart(',');

        // Parse time into a long and convert it fromUnix to date
        long time_long = long.Parse(time_trimmed);
        timestamp = DateTimeOffset.FromUnixTimeSeconds(time_long);

        // Set the time to localtime and ensure correct format
        string TimeFormat = timestamp.ToLocalTime().ToString(TimeForm);

        // Make resulting string and print it
        string result = $"{author} @ {TimeFormat}: {Message}";

        Console.WriteLine(result);
    }

}