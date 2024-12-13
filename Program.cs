using Gtk;

internal class _PasswordGenerator : Window
{
    private bool[] _settings = { false, false, false };
    
    /*
     * _settings[0] is a digits
     * _settings[1] is a signs
     * _settings[2] is a high register character
     */

    private string chars = "abcdefghijklmnopqrstuvwxyz";
    private int _lenght = 3;
    private Random _random = new Random();

    private Label _name = new Label("Password Generator v1.2");
    private Entry _password = new Entry();
    private SpinButton _lenghtEntry = new SpinButton(3, 16384, 1);
    private Button _acceptButton = new Button("Generate");

    private CheckButton _signButton = new CheckButton("Signs");
    private CheckButton _highButton = new CheckButton("High letters");
    private CheckButton _digitButton = new CheckButton("Digits");

    private _PasswordGenerator() : base("Password Generator")
    {
        DeleteEvent += DeleteWindowEvent;
        _password.IsEditable = false;
        _password.Text = "";
        _acceptButton.Clicked += GeneratePassword;

        var vbox = new Box(Orientation.Vertical, 10);

        vbox.PackStart(_name, true, true, 5);
        vbox.PackStart(_password, false, false, 0);
        vbox.PackStart(_lenghtEntry, false, false, 0);
        vbox.PackStart(_signButton, false, false, 0);
        vbox.PackStart(_highButton, false, false, 0);
        vbox.PackStart(_digitButton, false, false, 0);
        vbox.PackStart(_acceptButton, false, false, 0);

        Add(vbox);
        ShowAll();
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Password Generator v1.2");
        //if (args[0] == "-a")
            //Console.WriteLine(GeneratePassword());
        Application.Init();
        var app = new _PasswordGenerator();
        app.Resizable = false;
        app.DeleteEvent += delegate
        { 
            Application.Quit();
        };
        Application.Run();
    }

    private static void DeleteWindowEvent(object o, EventArgs args)
    {
        Application.Quit();
        Console.WriteLine("App closed");
    }

    private void GeneratePassword(object? o, EventArgs? args)
    {
        if (_settings[2])
            chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        if (_settings[0])
            chars += "0123456789";
        if (_settings[1])
            chars += "()/*-+?№!@#$%^&*_=<>[]{}:;,.";

        var random = new Random();
        char[] charArray = chars.ToCharArray();
        string genPass = "";

        for (var i = 1; i <= _lenght; i++)
        {
            genPass += charArray[random.Next(0, chars.Length)];
        }
        _password.Text = genPass;
    }
}
