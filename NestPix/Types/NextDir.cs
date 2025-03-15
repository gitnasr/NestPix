namespace NestPix.Types
{
    sealed internal class NextDir
    {


        public string? Current { get; } = null;
        public KeyValuePair<string, List<string>> Next { get; }

        public bool IsHasNext
        {
            get
            {
                return !string.IsNullOrEmpty(Next.Key) && Next.Value != null;
            }
        }

        public NextDir()
        {
            Current = null;
            Next = new KeyValuePair<string, List<string>>();
        }
        public NextDir(string current, KeyValuePair<string, List<string>> next)
        {
            Current = current;

            Next = next;
        }


    }
}
