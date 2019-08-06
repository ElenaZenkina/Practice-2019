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
        public static int width = 500;
        public static int height = 500;
        public static int tanks = 5;
        public static int apples = 5;
        public static int speed = 10;

        static Ini()
        {

        }

        public static void Init()
        {
            string[] inis = ReadIniFile();
            if (inis != null)
            {
                // Сделать проверку на диапазон допустимых значений
                width = StringToInt(inis[0]);
                height = StringToInt(inis[1]);
                tanks = StringToInt(inis[2]);
                apples = StringToInt(inis[3]);
                speed = StringToInt(inis[4]);
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
