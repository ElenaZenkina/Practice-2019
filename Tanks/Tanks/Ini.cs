using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public static class Ini
    {
        // Можно сделать проверку на диапазон допустимых значений для каждого параметра
        private static int width = 500;
        public static int Width
        {
            get { return width; }
            set { if (value > 0) { width = value; } }
        }

        private static int height = 500;
        public static int Height
        {
            get { return height; }
            set { if (value > 0) { height = value; } }
        }

        private static int tanks = 5;
        public static int Tanks
        {
            get { return tanks; }
            set { if (value > 0) { tanks = value; } }
        }

        private static int apples = 5;
        public static int Apples
        {
            get { return apples; }
            set { if (value > 0) { apples = value; } }
        }

        private static int speed = 10;
        public static int Speed
        {
            get { return speed; }
            set { if (value > 0) { speed = value; } }
        }

        public static void Init()
        {
            string[] inis = ReadIniFile();
            if (inis != null)
            {
                Width = StringToInt(inis[0]);
                Height = StringToInt(inis[1]);
                Tanks = StringToInt(inis[2]);
                Apples = StringToInt(inis[3]);
                Speed = StringToInt(inis[4]);
            }
        }

        private static string[] ReadIniFile()
        {
            string iniFileName = Path.Combine(Environment.CurrentDirectory, "ini.txt");
            try
            {
                return File.ReadAllLines(iniFileName);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static int StringToInt(string str)
        {
            MatchCollection myMatch = Regex.Matches(str, @"\d+");

            if (myMatch.Count == 0) { return -1; }

            int number;

            if (int.TryParse(myMatch[0].Value, out number))
                { return number; }
            else
                { return -1; }

        }
    }
}
