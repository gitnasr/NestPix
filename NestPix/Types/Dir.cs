namespace NestPix.Types
{
    sealed internal class Dir
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

        public Dir()
        {
            Current = null;
            Next = new KeyValuePair<string, List<string>>();
        }
        public Dir(string current, KeyValuePair<string, List<string>> next)
        {
            Current = current;

            Next = next;
        }


    }
}
