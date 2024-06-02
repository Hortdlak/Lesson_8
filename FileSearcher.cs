namespace Lesson_8
{
    public class FileSearcher
    {
        private string _extension;
        private string _searchText;

        public FileSearcher(string extension, string searchText)
        {
            _extension = extension;
            _searchText = searchText;
        }

        public void Search(string directory)
        {
            try
            {
                var files = Directory.EnumerateFiles(directory, $"*.{_extension}");
                foreach (var file in files)
                {
                    if (FileContainsText(file))
                    {
                        Console.WriteLine($"File: {file} contains the text: {_searchText}");
                    }
                }

                var dirs = Directory.EnumerateDirectories(directory);
                foreach (var dir in dirs)
                {
                    Search(dir);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in directory {directory}: {ex.Message}");
            }
        }

        private bool FileContainsText(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(_searchText))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file {path}: {ex.Message}");
            }
            return false;
        }
    }
}
