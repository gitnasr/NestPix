namespace NestPix.Services
{
    internal class ScanService
    {
        private string? CurrentPath { get; set; }
        public List<string> Dirs { get; private set; } = new List<string>();
        private int CurrentIndex { get; set; } = 0;

        public ScanService(string path)
        {
            CurrentPath = path;
        }
        public void GetAllDirectories()
        {
            try
            {
                if (CurrentPath == null)
                {
                    throw new Exception("Please Provide a valid path");
                }
                string[] Directories = Directory.GetDirectories(CurrentPath);


                foreach (var dir in Directories)
                {

                    DirectoryInfo info = new DirectoryInfo(dir);

                    Dirs.Add(dir);




                }
                if ((CurrentIndex + 1) > Dirs.Count)
                {
                    return;
                }
                CurrentPath = Dirs[CurrentIndex++];
                GetAllDirectories();
            }
            catch (UnauthorizedAccessException Ex)
            {

                if ((CurrentIndex + 1) > Dirs.Count)
                {
                    return;
                }
                CurrentPath = Dirs[CurrentIndex++];
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
