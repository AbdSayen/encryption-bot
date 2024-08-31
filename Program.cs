using System;
using System.Text;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("      Добро пожаловать в Шифровальню");
            Console.WriteLine("======================================");
            Console.WriteLine("1 - Создать шифр");
            Console.WriteLine("2 - Расшифровать шифр");
            Console.WriteLine("3 - Подробнее о программе");
            Console.WriteLine("4 - Выйти");
            Console.WriteLine("======================================");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">>> ");
            Console.ResetColor();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateCipher();
                    break;
                case "2":
                    DecryptCipher();
                    break;
                case "3":
                    ShowDetails();
                    break;
                case "4":
                    Console.WriteLine("Выход из программы...");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню...");
            Console.ReadKey();
        }
    }

    static void CreateCipher()
    {
        Console.WriteLine("=== Создание шифра ===");
        Console.WriteLine("Введите текст для шифровки:");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(">>> ");
        Console.ResetColor();
        string inputText = Console.ReadLine();

        Console.WriteLine("Введите любое ключ-слово для шифрации. Этот код понадобится вам для расшифровки:");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(">>> ");
        Console.ResetColor();
        string keyWord = Console.ReadLine();

        string cipherText = Encrypt(inputText, keyWord);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nВаш шифр: {cipherText}");
        Console.ResetColor();
    }

    static void DecryptCipher()
    {
        Console.WriteLine("=== Расшифровка шифра ===");
        Console.WriteLine("Введите шифр для расшифровки:");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(">>> ");
        Console.ResetColor();
        string cipherText = Console.ReadLine();

        Console.WriteLine("Введите ключ-слово для расшифровки:");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(">>> ");
        Console.ResetColor();
        string keyWord = Console.ReadLine();

        string decryptedText = Decrypt(cipherText, keyWord);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nРасшифрованный текст: {decryptedText}");
        Console.ResetColor();
    }

    static void ShowDetails()
    {
        Console.WriteLine("=== О программе ===");
        Console.WriteLine("Эта программа позволяет зашифровать и расшифровать текст с использованием ключевого слова.");
        Console.WriteLine("Для шифровки используется простое перемещение символов на основе ключевого слова.");
        Console.WriteLine("Шифр всегда отображается латиницей.");
    }

    static string Encrypt(string text, string key)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            char keyChar = key[i % key.Length];
            char encryptedChar = (char)(c + keyChar);
            result.Append(encryptedChar);
        }
        return ConvertToBase64(result.ToString());
    }

    static string Decrypt(string cipherText, string key)
    {
        string decodedText = ConvertFromBase64(cipherText);
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < decodedText.Length; i++)
        {
            char c = decodedText[i];
            char keyChar = key[i % key.Length];
            char decryptedChar = (char)(c - keyChar);
            result.Append(decryptedChar);
        }
        return result.ToString();
    }

    static string ConvertToBase64(string text)
    {
        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        return Convert.ToBase64String(textBytes);
    }

    static string ConvertFromBase64(string base64Text)
    {
        byte[] textBytes = Convert.FromBase64String(base64Text);
        return Encoding.UTF8.GetString(textBytes);
    }
}
