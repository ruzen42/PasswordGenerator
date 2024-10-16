using Gtk;

class PasswordGeneratorApp : Window
{
    bool AreDigits = false;
    bool AreSigns = false;
    bool AreHighRegister = false;

    string chars = "abcdefghijklmnopqrstuvwxyz";
    int lenght = 3;
    Random rand = new Random();

    private Label name = new Label("Password Generator v1.2");
    private Entry password = new Entry();
    private SpinButton lenghtEntry = new SpinButton(3, 16384, 1);
    private Button AcceptButton = new Button("Generate");

    CheckButton SignButton = new CheckButton("Signs");
    CheckButton HighButton = new CheckButton("High letters");
    CheckButton DigitButton = new CheckButton("Digits");

    private PasswordGeneratorApp() : base("Password Generator")
    {
        DeleteEvent += DeleteWindowEvent;
        password.IsEditable = false;
        password.Text = "";
        AcceptButton.Clicked += Gen;

        Box vbox = new Box(Orientation.Vertical, 10);

        vbox.PackStart(name, true, true, 5);
        vbox.PackStart(password, false, false, 0);
        vbox.PackStart(lenghtEntry, false, false, 0);
        vbox.PackStart(SignButton, false, false, 0);
        vbox.PackStart(HighButton, false, false, 0);
        vbox.PackStart(DigitButton, false, false, 0);
        vbox.PackStart(AcceptButton, false, false, 0);

        Add(vbox);
        ShowAll();
    }

    private static void Main()
    {
        Application.Init();

        new PasswordGeneratorApp();

        Application.Run();
    }

    private void DeleteWindowEvent(object o, EventArgs args)
    {
        Application.Quit();
        Console.WriteLine("App closed");
    }

    private void Gen(object? o, EventArgs? args)
    {
        if (DigitButton.Active)
        {
            AreDigits = true;
        }
        else
        {
            AreDigits = false;
        }

        if (SignButton.Active)
        {
            AreSigns = true;
        }
        else
        {
            AreSigns = false;
        }

        if (HighButton.Active)
        {
            AreHighRegister = true;
        }
        else
        {
            AreHighRegister = false;
        }


        lenght = Convert.ToInt32(lenghtEntry.Value);
        string genpass = "";
        if (AreHighRegister) chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        else chars = "abcdefghijklmnopqrstuvwxyz";
        if (AreDigits) chars += "0123456789";
        else chars = "abcdefghijklmnopqrstuvwxyz";
        if (AreSigns) chars += "()/*-+?№!@#$%^&*_=<>[]{}:;,.";
        else chars = "abcdefghijklmnopqrstuvwxyz";

        if (AreHighRegister)
            chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        if (AreDigits)
            chars += "0123456789";

        if (AreSigns)
            chars += "()/*-+?№!@#$%^&*_=<>[]{}:;,.";

        char[] charArray = chars.ToCharArray();

        for (int i = 1; i <= lenght; i++)
        {
            genpass = genpass + charArray[rand.Next(0, chars.Length)];
        }

        password.Text = genpass;
    }
}


