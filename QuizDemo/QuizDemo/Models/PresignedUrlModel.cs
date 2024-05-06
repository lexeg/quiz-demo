using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace QuizDemo.Models;

public class PresignedUrlModel
{
    public Guid BranchOfficeId { get; set; }

    public Guid EducationalProgramId { get; set; }

    public Guid TestId { get; set; }

    public string CreatePresignedUrl(DateTime expiredDate)
    {
        var asciiBytes = Encoding.ASCII.GetBytes($"{BranchOfficeId}.{EducationalProgramId}.{TestId}");
        var temp = asciiBytes.Aggregate<byte, long>(0, (current, item) => current + item);
        var key = expiredDate.Ticks + temp;
        return GetUrlChunk(key);
    }

    private static string GetUrlChunk(long key) => WebEncoders.Base64UrlEncode(BitConverter.GetBytes(key));
}