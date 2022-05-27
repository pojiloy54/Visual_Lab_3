using System;

namespace Visual_Lab_3
{
    class Program
    {
		static void Main(string[] args)
		{
			RomanNumber testr = new RomanNumber(20);
			Console.WriteLine($"Первое число {testr}");
			RomanNumber testr2 = new RomanNumber(5);
			Console.WriteLine($"Второе число {testr2}");
			Console.WriteLine($"Сложение = {testr + testr2}");
			Console.WriteLine($"Вычитание = {testr - testr2}");
			Console.WriteLine($"Умножение {testr * testr2}");
			Console.WriteLine($"Деление {testr / testr2}");
			Console.WriteLine("");
			Console.WriteLine($"Изначальное число {testr2.ToString()}");
			var clon = (RomanNumber)testr2.Clone();
			Console.WriteLine($"Скопированное число {clon.ToString()}\n");
			RomanNumber sort1 = new RomanNumber(25);
			RomanNumber sort2 = new RomanNumber(5);
			RomanNumber sort3 = new RomanNumber(10);
			RomanNumber[] mas = { sort1, sort2, sort3 };
			Console.WriteLine($"Изначальный массив");
			for (int i = 0; i < 3; i++) Console.WriteLine($"{mas[i].ToString()}");
			Array.Sort(mas);
			Console.WriteLine($"Отсортированный массив");
			for (int i = 0; i < 3; i++) Console.WriteLine($"{mas[i].ToString()}");
		}
	}
}
