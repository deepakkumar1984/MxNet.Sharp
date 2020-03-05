namespace MxNet
{
    public class Slice
    {
        public Slice(int begin, int? end)
        {
            Begin = begin;
            End = end;
        }

        public int Begin { get; set; }

        public int? End { get; set; }

        public override string ToString()
        {
            if (End.HasValue)
                return string.Format("{0}:{1}", Begin, End.Value);
            return string.Format("{0}:", Begin);
        }
    }
}