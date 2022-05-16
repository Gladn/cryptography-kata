using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

class Class
{
    public static string Encrypt(string text, int key)
    {
        char[] alphabet_cyrrilic = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 
            'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

        char[] encryptedMessage = new char[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsDigit(text[i])) encryptedMessage[i] = text[i];
            else
            {
                int index = Array.IndexOf(alphabet_cyrrilic, text[i]);                
                int newIndex = (index + key) % 33;
                char newLetter = alphabet_cyrrilic[newIndex];
                encryptedMessage[i] = newLetter;
            }
        }
        string enMessage = String.Join("", encryptedMessage);
        return enMessage;
    }

    static string Decrypt(string text, int key)
    {
        char[] alphabet_cyrrilic = new char[] { 'я', 'ю', 'э', 'ь', 'ы', 'ъ', 'щ', 'ш', 'ч', 'ц', 'х', 'ф', 'у', 'т',
            'с', 'р', 'п', 'о', 'н', 'м', 'л', 'к', 'й', 'и', 'з', 'ж', 'ё', 'е', 'д', 'г', 'в', 'б', 'а' };

        char[] encryptedMessage = new char[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsDigit(text[i])) encryptedMessage[i] = text[i];
            else
            {
                int index = Array.IndexOf(alphabet_cyrrilic, text[i]);
                int newIndex = (index + key) % 33;
                char newLetter = alphabet_cyrrilic[newIndex];
                encryptedMessage[i] = newLetter;
            }
        }
        string enMessage = string.Join("", encryptedMessage);
        return enMessage;
    }

    static void Main(string[] args)
    {
        string text1 = "автомобиль";
        int key1 = 18;
        Console.WriteLine("Текст: " + text1);
        Console.WriteLine("Ключ: " + key1);
        Console.WriteLine("Шифр текст: " + Encrypt(text1, key1));

        Console.WriteLine("");
        string text2 = "аыпьэщчкэуй";
        int key2 = 11;
        Console.WriteLine("Криптограмма: " + text2);
        Console.WriteLine("Ключ: " + key2);
        Console.WriteLine("Дешифр текст: " + Decrypt(text2, key2));

        Console.WriteLine("");
        string text3 = "уязвимость";
        string text3k = "якунфшъэюз";
        Console.WriteLine("Текст: " + text3);
        Console.WriteLine("Криптограмма: " + text3k);      
        for (int i = 0; i < 30; i++)
        {
            if (Encrypt(text3, i) == text3k)
            {
                Console.Write("Ключ: "); 
                Console.WriteLine(i);
            }
        }

        Console.WriteLine("");
        string text4 = "ойюклзёщлвш";
        Console.WriteLine("Текст: " + text4);
        Console.WriteLine("Грубый перебор: ");
        for (int i = 0; i < 21; i++)
        {
            Console.WriteLine(i + " " + Encrypt(text4, i) + " ");
        }
        Console.ReadLine();
    }

}