namespace Lesson_8
{
    internal class Class1
    {
        public void CopyFile(string path, string fileName2)
        {
            File.Copy(path, fileName2);
        }

        public void MyCopyFile(string path, string fileName1, string fileName2)
        {

            if (!Path.Exists(path))
            {
                //path = @"C:\";
                //Process.Start(path);

                Console.WriteLine("Файл отсутствует");
                return;
            }
            using (StreamReader sr = new StreamReader(Path.Combine(path, fileName1)))
            {
                using (StreamWriter sw = new StreamWriter(fileName2))
                {
                    sw.WriteLine(sr.ReadToEnd());
                    string str = sr.ReadLine();
                }
            }
        }
    }
}
