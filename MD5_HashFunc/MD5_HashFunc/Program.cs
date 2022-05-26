using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
class Class
{
	public static string ComputeMd5Hash(string message)
	{
		using (MD5 md5 = MD5.Create())
		{
			byte[] input = Encoding.ASCII.GetBytes(message);
			byte[] hash = md5.ComputeHash(input);

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < hash.Length; i++)
			{
				sb.Append(hash[i].ToString("X2"));
			}
			return sb.ToString();
		}
	}
	public static string GenerateCoupon(int length, Random random)
	{
		string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
		StringBuilder result = new StringBuilder(length);
		for (int i = 0; i < length; i++)
		{
			result.Append(characters[random.Next(characters.Length)]);
		}
		return result.ToString();
	}


	static void Main(string[] args)
	{
		//MD5 
		string message = "password";
		Console.WriteLine("Текст: " + message);
		Console.WriteLine("MD5 хеш текста: " + ComputeMd5Hash(message));


		//MD5 rand
		Console.WriteLine();
		Console.WriteLine("Генерация псевдослучайных чисел: ");
		Random rnd = new Random();
		string[] coupon = new string[10];
		for (int i = 0; i < coupon.Length; i++)
		{
			coupon[i] = GenerateCoupon(10, rnd);
			string hash = ComputeMd5Hash(coupon[i]);
			string hex4 = hash.Substring(0, 4);
			var dec = Convert.ToUInt32(hex4, 16);
			Console.WriteLine(hex4 + " " + dec);
		}


		//MD5 поиск частичных коллизий
		Console.WriteLine();
		Console.WriteLine("Поиск частичных коллизий (ABCD): ");
		//string value1 = "value0";
		Random rndk = new Random();
		string[] couponk = new string[10000000];
		for (int i = 0; i < couponk.Length; i++)
		{
			couponk[i] = GenerateCoupon(10, rndk);
			string hashk = ComputeMd5Hash(couponk[i]);
			if (hashk.Substring(0, 5) == "ABCDE")
			{
				Console.WriteLine(couponk[i] + " " + hashk);
			}

		}


		//
		//Console.ReadLine();	
	}
}
