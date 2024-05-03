using System.Text;

namespace QuizDemo.Helpers;

internal static class TestResultHelper
{
    public static string CreatePresignedUrl(DateTime expiredDate, string salt)
    {
        var bytes = Encoding.UTF8.GetBytes(salt + expiredDate.ToString("s"));
        return string.Concat(System.Security.Cryptography.SHA1.HashData(bytes).Select(b => b.ToString("x2")))[8..];
    }
}