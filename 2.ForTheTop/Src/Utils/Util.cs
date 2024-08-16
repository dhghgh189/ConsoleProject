using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Utils
{
    public class Util
    {
        public static void Print(string msg = "", ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(msg);
            Console.ResetColor();
        }

        public static void PrintLine(string msg = "", ConsoleColor color = ConsoleColor.White)
        {
            Print(msg, color);
            Console.WriteLine();
        }

        public static void ClearBuffer()
        {
            // 이전 씬에서 입력받았던 키가 처리되버리는 것을 방지
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        // data 파일 내용을 수정하지 못하도록 변환해서 저장 
        public static void CreateDataFile(string jsonPath, string filePath)
        {
            // HARD CODE
            string path = $"{Define.RESOURCES_PATH}\\Data\\{jsonPath}";

            string jsonStr = File.ReadAllText(path);

            if (string.IsNullOrEmpty(jsonStr))
            {
                Util.PrintLine($"No Data", ConsoleColor.DarkRed);
                Util.PrintLine($"   {path}");
                return;
            }

            string targetPath = $"{Environment.CurrentDirectory}\\Resources\\Data\\{filePath}";

            using (FileStream file = new FileStream(targetPath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    foreach (char c in jsonStr)
                    {
                        sw.Write($"{(int)c}_");
                    }
                }             
            }

            Util.PrintLine("Save Complete", ConsoleColor.Green);
            Util.PrintLine($"   {targetPath}");
        }
    }
}
