using System.Text;
using ClassLibraryLabs;
using ClassLibraryLabs.Lab2;
using ClassLibraryLabs.Lab3;
using McMaster.Extensions.CommandLineUtils;

const string DefaultInputFileName = "INPUT.TXT";
const string DefaultOutputFileName = "OUTPUT.TXT";

Console.OutputEncoding = Encoding.Unicode;

var app = new CommandLineApplication
{
    Name = "D_Kravchuk",
    Description = "Crossplatform lab work 4",
};

app.HelpOption();

app.Command("version", versionCmd =>
{
    versionCmd.Description = "Show version";
    versionCmd.OnExecute(() =>
    {
        Console.WriteLine("Author: Dariia Kravchuk, IPZ-31");
        Console.WriteLine("Version: 1.0.0");
    });
});

app.Command("set-path", setPath =>
{
    setPath.Description = "Set path to folder with input and output files";

    var path = setPath.Option("-p|--path", "Path to folder", CommandOptionType.SingleValue).IsRequired();

    setPath.OnExecute(() =>
    {
        var labPath = path.Value();

        if (OperatingSystem.IsWindows())
        {
            Environment.SetEnvironmentVariable("LAB_PATH", labPath, EnvironmentVariableTarget.User);
            Console.WriteLine($"LAB_PATH set to {labPath} and saved for user on Windows.");
        }
        else if (OperatingSystem.IsMacOS() || OperatingSystem.IsLinux())
        {
            var userHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string shellConfigPath;

            if (OperatingSystem.IsMacOS())
            {
                shellConfigPath = Path.Combine(userHome, ".bash_profile");
            }
            else
            {
                shellConfigPath = Path.Combine(userHome, ".bashrc");
            }

            Environment.SetEnvironmentVariable("LAB_PATH", labPath);
            Console.WriteLine($"LAB_PATH set to {labPath} for the current session.");

            var exportCommand = $"\nexport LAB_PATH=\"{labPath}\"\n";
            File.AppendAllText(shellConfigPath, exportCommand);
            Console.WriteLine($"LAB_PATH saved to {shellConfigPath} for future sessions.");

            var lines = File.ReadAllLines(shellConfigPath);
            foreach (var line in lines.Where(line => line.StartsWith("export LAB_PATH=")))
            {
                var value = line.Split('=')[1].Trim('"');
                Environment.SetEnvironmentVariable("LAB_PATH", value);
                Console.WriteLine($"LAB_PATH loaded into current session as: {value}");
            }
        }
        else
        {
            Console.WriteLine("Unsupported operating system. This tool works on Windows, macOS, and Linux.");
        }

        return 0;
    });
});


app.Command("run", run =>
{
    run.Description = "Run lab";
    run.OnExecute(() =>
    {
        Console.WriteLine("Specify the lab to run");
        run.ShowHelp();
        return 1;
    });

    var input = run.Option("-i|--input", "Input file path", CommandOptionType.SingleValue, true);
    var output = run.Option("-o|--output", "Output file path", CommandOptionType.SingleValue, true);

     run.Command("lab1", lab1 =>
    {
        lab1.Description = "Run lab 1";
        lab1.OnExecute(() =>
        {
            var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, DefaultInputFileName);
            var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, DefaultOutputFileName);
            Lab1.Execute(inputFilePath ?? "", outputFilePath ?? "");
            return 0;
        });
    });

    run.Command("lab2", lab2 =>
    {
        lab2.Description = "Run lab 2";
        lab2.OnExecute(() =>
        {
            var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }
    
            var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, DefaultInputFileName);
            var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, DefaultOutputFileName);
            Lab2.Execute(inputFilePath ?? "", outputFilePath ?? "");
            return 0;
        });
    });
    
    run.Command("lab3", lab3 =>
    {
        lab3.Description = "Run lab 3";
        lab3.OnExecute(() =>
        {
            var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
            Console.WriteLine("hello");
            Console.WriteLine(folderPath);
            Console.WriteLine("hello");
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }
    
            var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, DefaultInputFileName);
            Console.WriteLine(inputFilePath);
            var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, DefaultOutputFileName);
            Lab3.Execute(inputFilePath ?? "", outputFilePath ?? "");
            return 0;
        });
    });

});

app.OnExecute(() =>
{
    Console.WriteLine("Specify a subcommand");
    app.ShowHelp();
    return 1;
});

try
{
    return app.Execute(args);
}
catch (Exception e)
{
    Console.WriteLine($"An error occurred: {e.Message}");
    return 1;
}