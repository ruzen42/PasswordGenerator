using System.IO;

class Program
{
    static void Main()
    {
        string? line;

        bool AreDigits = false;
        bool AreSigns = false;
        bool AreHighRegister = false;

        try
        {
            StreamReader config = new StreamReader("config");

            line = config.ReadLine();
            if (line == "digit = true")
            {
                AreDigits = true;
            }
            line = config.ReadLine();
            if (line == "high = true")
            {
                AreHighRegister = true;
            }

            line = config.ReadLine();
            if (line == "sign = true")
            {
                AreSigns = true;
            }
        }
        catch
        {
            Console.WriteLine("Config file is lost");
        }

        string chars = "abcdefghijklmnopqrstuvwxyz";
        if (AreHighRegister) chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        if (AreDigits) chars += "0123456789";
        if (AreSigns) chars += "()/*-+?№!@#$%^&*_=<>[]{}:;,.";
        Console.Write("длина: ");
        int length = Convert.ToInt32(Console.ReadLine());

        char[] charArray = chars.ToCharArray();
        Random rand = new Random();
        string password = "";

        for (int i = 1; i <= length; i++)
        {
            password = password + charArray[rand.Next(0, chars.Length)];
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Ваш пароль: " + password);
    }
}


