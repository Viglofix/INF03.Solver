namespace Inf03.Solver.Business.Extensions;
    public static class DataStructureExtensions
    {
        public static string Substring2(this string value, int startIndex, int endIndex)
        {
        return value.Substring(startIndex, (endIndex - startIndex));
        }
    }
