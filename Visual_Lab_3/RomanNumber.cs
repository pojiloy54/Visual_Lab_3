using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Lab_3
{
    public class RomanNumber : ICloneable, IComparable
    {
        private int romnum;
        //Конструктор получает представление числа n в римской записи
        public RomanNumber(ushort n)
        {
            if (n == 0) throw new RomanNumberException();
            romnum = (int)n;
        }

        //Перевод одного символа из римской записи в дестяичную
        public static int CharTo_int(char symbol)
        {
            if (symbol == 'I') return 1;
            if (symbol == 'V') return 5;
            if (symbol == 'X') return 10;
            if (symbol == 'L') return 50;
            if (symbol == 'C') return 100;
            if (symbol == 'D') return 500;
            if (symbol == 'M') return 1000;
            return 0;
        }

        //Перевод всего римского числа в десятичную
        public static int RomTo_int(string s)
        {
            int res = 0;
            for (int i = 0; i < (s.Length - 1); ++i)
            {
                if (CharTo_int(s[i]) < CharTo_int(s[i + 1]))
                    res -= CharTo_int(s[i]);
                else
                    res += CharTo_int(s[i]);
            }
            res += CharTo_int(s[s.Length - 1]);
            return res;
        }

        //Сложение римских чисел
        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            int num = RomTo_int(n1.ToString()) + RomTo_int(n2.ToString());
            return new RomanNumber((ushort)num);
        }
        //Вычитание римских чисел
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            int num = RomTo_int(n1.ToString()) - RomTo_int(n2.ToString());
            if (num <= 0) throw new RomanNumberException();
            return new RomanNumber((ushort)num);
        }
        //Умножение римских чисел
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            int num = RomTo_int(n1.ToString()) * RomTo_int(n2.ToString());
            return new RomanNumber((ushort)num);
        }
        //Целочисленное деление римских чисел
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            int num = RomTo_int(n1.ToString()) / RomTo_int(n2.ToString());
            return new RomanNumber((ushort)num);
        }
        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] numerals = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            string result = "";
            int number = romnum;
            for (int i = 0; i < 13; i++)
            {
                while (number >= values[i])
                {
                    number -= values[i];
                    result += numerals[i];
                }
            }
            return result;
        }
        public object Clone()
        {
            return new RomanNumber((ushort)romnum);
        }

        public int CompareTo(object? o)
        {
            if (o is RomanNumber num) return romnum - RomanNumber.RomTo_int(num.ToString());
            else throw new ArgumentException("Некорректное значение параметра");
        }
    }
}
