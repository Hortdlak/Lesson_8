using System.Diagnostics;
using System.Text;

namespace Lesson_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Задание 1:
            //Class1 class1 = new Class1();
            //class1.MyCopyFile(@"C:\Users\админ\source\repos\Lesson_8\", "Class1.cs", "3.txt");
            //File.Copy(@"C:\Users\админ\source\repos\Lesson_8\Class1.cs", "text.txt");
            #endregion

            #region Задание 2:
            //var mainPath = args[0];
            //string fileName = args[1];

            //SomeMethod(mainPath, fileName);


            #endregion

            #region Задание 3:

            //MyFile(@"C:\Users\админ\source\repos\Lesson_8\bin\Debug\net8.0\text.txt");


            #endregion

            #region Задание 4:

            //MyFile2(@"C:\Users\админ\source\repos\Lesson_8\bin\Debug\net8.0\text2.txt");

            #endregion

            #region HW: Написать утилиту которая ищет файлы определенного расширения с указанным текстом. Рекурсивно.

            if (args.Length < 3)
            {
                Console.WriteLine("Usage: utility.exe <directory> <extension> <text>");
                return;
            }

            string directory = args[0];
            string extension = args[1];
            string searchText = args[2];

            FileSearcher searcher = new FileSearcher(extension, searchText);
            searcher.Search(directory);
        
        #endregion

    }

        public static void SomeMethod(string directory, string fileName) 
        {
            var dirs = Directory.EnumerateDirectories(directory);
            var files = Directory.EnumerateFiles(directory);
            foreach ( var file in files)
            {
                if (file.Contains(fileName))
                {
                    Console.WriteLine($"Искомый файл: {fileName} находится в {directory}");
                    break;
                }
            }
            foreach (var dir in dirs)
            {
                SomeMethod(dir, fileName);
            }
        }

        public static void MyFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("no file");
            }

            using (StreamReader  sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string value = sr.ReadToEnd();

                    if (value.Contains("444"))
                    {
                        Console.WriteLine(value);
                    }
                }
                
            }
        }
        public static void MyFile2(string path)
        {
            using (FileStream fS = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (BufferedStream bS = new BufferedStream(fS))
                {
                    byte[] bytes = new byte[fS.Length];

                    bS.Read(bytes, 0, bytes.Length);

                    string date = Encoding.UTF8.GetString(bytes);

                    string newData =Environment.NewLine + "New string new less";

                    byte[] newBytes = Encoding.UTF8.GetBytes(newData);

                    bS.Write(newBytes, 0, newBytes.Length);
                }   
                
            }

            
        }
    }
}
