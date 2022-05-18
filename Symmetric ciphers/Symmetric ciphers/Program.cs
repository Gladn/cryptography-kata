using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RC4_Testing;

class Program
{
    static string ByteToBinary(byte[] getByte)
    {
        StringBuilder sb = new StringBuilder(getByte.Length * 8);
        foreach (byte b in getByte)
        {
            sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
        }
        string binaryText = sb.ToString();
        return binaryText;
    }

    public static string VernamXor(string key, string input)
    {
        char[] xor = new char[key.Length];
        for (int i = 0; i < key.Length; i++)
        {
            xor[i] = key[i] == input[i] ? '0' : '1';
        }
        return new string(xor);
    }

    public static byte[] BinaryToByte(string input)
    {
        int numOfBytes = input.Length / 8;
        byte[] bytes = new byte[numOfBytes];
        for (int i = 0; i < numOfBytes; ++i)
        {
            bytes[i] = Convert.ToByte(input.Substring(8 * i, 8), 2);
        }
        return bytes;
    }

    static void LineRand(ulong n, ulong x0, ulong a, ulong b, ulong c, ulong k)
    {
        if (k < n)
        {
            x0 = (a * x0 + b) % c;
            k++;
            Console.Write($"{k} - {x0}; ");  
            LineRand(n, x0, a, b, c, k);
        }
        else
        {
            return;
        }       
    }

    public static byte[] Encrypt(byte[] pwd, byte[] data)
    {
        int a, i, j, k, tmp;
        int[] key, box;
        byte[] cipher;

        key = new int[256];
        box = new int[256];
        cipher = new byte[data.Length];

        for (i = 0; i < 256; i++)
        {
            key[i] = pwd[i % pwd.Length];
            box[i] = i;
        }
        for (j = i = 0; i < 256; i++)
        {
            j = (j + box[i] + key[i]) % 256;
            tmp = box[i];
            box[i] = box[j];
            box[j] = tmp;
        }
        for (a = j = i = 0; i < data.Length; i++)
        {
            a++;
            a %= 256;
            j += box[a];
            j %= 256;
            tmp = box[a];
            box[a] = box[j];
            box[j] = tmp;
            k = box[((box[a] + box[j]) % 256)];
            cipher[i] = (byte)(data[i] ^ k);
        }
        return cipher;
    }
    public static byte[] Decrypt(byte[] pwd, byte[] data)
    {
        return Encrypt(pwd, data);
    }


    
    //Генерация псевдослучайного слова  
    public static void keyItemRC4(byte[] S, int n)
    {        
        int x = 0;
        int y = 0;
        byte tmp; byte[] t = new byte[S.Length];
        
        for (int i = 0; i < Math.Pow(2, n); i++)
        {
            Console.Write("S = ( ");
            foreach (byte bytes in S) Console.Write(bytes + " ");
            Console.Write(") i = " + x + " j = " + y + "\n");
            x = (x + 1) % 8;
            y = (y + S[x]) % 8;

            tmp = S[y];
            S[y] = S[x];
            S[x] = tmp;

            t[i] = S[(S[x] + S[y]) % 8];
        }
        //Console.Write(" t =  ");
        //foreach (byte bytes in t) Console.Write(bytes + " ");
    }


    static void Main(string[] args)
    {
        //Шифр Вернама https://clck.ru/TQFhp
        //n1 = 73, n2 = 216, n3 = 4, k1 = 30, k2 = 57, k3 = 109.
        byte[] VernamText = {73, 216, 4};
        byte[] VernamKey = { 30, 57, 109 };
        Console.WriteLine("Текст n в двоичном коде: " + ByteToBinary(VernamText));
        Console.WriteLine("Ключ k в двоичном коде:  " + ByteToBinary(VernamKey));
        
        string VernamEncrypt = VernamXor(ByteToBinary(VernamKey), ByteToBinary(VernamText));
        Console.WriteLine("Шифр Вернама(двоичный): " + VernamEncrypt);

        Console.Write("Шифр Вернама: ");
        foreach (byte bytes in BinaryToByte(VernamEncrypt)) Console.Write(bytes + " "); 
        
        string VernamDecrypt = VernamXor(ByteToBinary(VernamKey), VernamEncrypt);       
        Console.WriteLine();
        Console.WriteLine("Дешифр Вернама(двоичный): " + VernamDecrypt);
        Console.Write("Дешифр Вернама: ");
        foreach (byte bytes in BinaryToByte(VernamDecrypt)) Console.Write(bytes + " ");



        //Линейный конгруэнтный генератор https://clck.ru/hGkcq
        //a=2916, b=1068, c=3869, x0=3641
        Console.Write("\n\n"); 
        Console.WriteLine("10 псевдослучайных чисел: ");
        ulong n = 10; ulong x0 = 3641; ulong a = 2916; ulong b = 1068; ulong c = 3869; ulong k = 0;
        LineRand(n, x0, a, b, c, k);



        //Поточный шифр RC4 https://ru.wikipedia.org/wiki/RC4
        //n=3, S=25031476
        Console.Write("\n\n");
        int N = 3; byte[] S = { 2,5,0,3,1,4,7,6 };
        keyItemRC4(S, N);



        //n=3, L=3, K0=0, K1=4, K2=4
        Console.Write("\n\n");
        byte[] key = {0, 4, 4};
        RC4 encoder = new RC4(key);        
        byte[] testBytes = { 0, 1, 2, 3, 4, 5, 6, 7 };
        byte[] result = encoder.Encode(testBytes, testBytes.Length);
        Console.Write("Шифр RC4: ");
        foreach (byte bytes in result) Console.Write(bytes + " ");
        

        Console.ReadLine();

    }

}