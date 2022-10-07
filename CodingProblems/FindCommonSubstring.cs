namespace CodingProblems;
public class FindCommonSubstring
{
    public static List<string> GetCommonSubstring(string a, string b)
    {
        List<string> possibleMatches = new();
        int[,] matrix = new int[a.Length, b.Length];
        int matchingCharacterCount = 0;
        List<(int, int)> matrixPosition = new();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (a.ElementAt(i) == b.ElementAt(j))
                {
                    int previous = i > 0 && j > 0 ? matrix[i - 1, j - 1] : 0;
                    matrix[i, j] = previous + 1;
                    if (matchingCharacterCount < previous + 1)
                    {
                        matchingCharacterCount = previous + 1;
                        matrixPosition.Clear();
                        matrixPosition.Add((i, j));
                    }
                    else if (matchingCharacterCount == previous + 1)
                    {
                        matrixPosition.Add((i, j));
                    }
                }
            }
        }

        foreach (var match in matrixPosition)
        {
            possibleMatches.Add(a.Substring(match.Item1 + 1 - matchingCharacterCount, matchingCharacterCount));
        }

        return possibleMatches;
    }

}
