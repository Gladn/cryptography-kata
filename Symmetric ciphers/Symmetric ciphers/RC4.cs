using System;
using System.Linq;


namespace RC4_Testing
{
    public class RC4
    {
        byte[] S = new byte[8];

        int x = 0;
        int y = 0;

        public RC4(byte[] key)
        {
            init(key);
        }

        // Key-Scheduling Algorithm 
        // Алгоритм ключевого расписания 
        private void init(byte[] key)
        {
            int keyLength = key.Length;

            for (int i = 0; i < 8; i++)
            {
                S[i] = (byte)i;
            }

            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                j = (j + S[i] + key[i % keyLength]) % 8;
                S.Swap(i, j);
            }
        }

        public byte[] Encode(byte[] dataB, int size)
        {
            byte[] data = dataB.Take(size).ToArray();

            byte[] cipher = new byte[data.Length];

            for (int m = 0; m < data.Length; m++)
            {
                cipher[m] = (byte)(data[m] ^ keyItem());
            }

            return cipher;
        }
        public byte[] Decode(byte[] dataB, int size)
        {
            return Encode(dataB, size);
        }

        // Pseudo-Random Generation Algorithm 
        // Генератор псевдослучайной последовательности 
        private byte keyItem()
        {
            Console.Write("S = ( ");
            foreach (byte bytes in S) Console.Write(bytes + " ");
            Console.Write(") i = " + x + " j = " + y + "\n");
            x = (x + 1) % 8;
            y = (y + S[x]) % 8;

            S.Swap(x, y);

            return S[(S[x] + S[y]) % 8];
        }
    }

    static class SwapExt
    {
        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
