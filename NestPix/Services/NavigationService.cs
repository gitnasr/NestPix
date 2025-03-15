namespace NestPix.Services
{
    internal class NavigationService : FilesService
    {
        int currentDirIndex = 0;
        int currentContentIndex = -1;

        public int GetDirsCount()
        {

            if (ImageFiles.Count == 0)
            {
                throw new Exception("No Images Found");
            }

            return ImageFiles.Keys.Count;


        }

        public List<string> GetDirContent(int index)
        {
            if (ImageFiles.Count == 0)
            {
                throw new Exception("No Images Found");
            }

            return ImageFiles.ElementAtOrDefault(index).Value;
        }
        public List<string> GetDirContent(string folder_path)
        {
            if (ImageFiles.Count == 0)
            {
                throw new Exception("No Images Found");
            }

            return ImageFiles[folder_path];
        }
        public string GetNext()
        {

            if (ImageFiles.Count == 0)
            {
                throw new Exception("No Images Found");
            }

            var currentDir = ImageFiles.ElementAt(currentDirIndex);


            // check if we have image with the new index;

            if (currentDir.Value.ElementAtOrDefault(++currentContentIndex) == null)
            {
                currentContentIndex = -1;
                // No More Images in this dir 

                // No More 
                //Move to NextFolder
                var nextFolder = GetDirContent(++currentDirIndex);
                // check if there next folder
                if (nextFolder == null)
                {
                    throw new Exception("No More Images");
                }

                return ImageFiles.ElementAt(currentDirIndex).Value.ElementAt(++currentContentIndex);



            }

            return ImageFiles.ElementAt(currentDirIndex).Value.ElementAt(currentContentIndex);



        }
    }
}
