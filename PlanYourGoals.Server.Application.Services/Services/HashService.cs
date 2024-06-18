using System.Security.Cryptography;
using System.Text;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;

namespace PlanYourGoals.Server.Application.Services.Services;

public class HashService : IHashService
{
    public async Task<string> GetHashAsync(string plainText)
    {
        var data = Encoding.UTF8.GetBytes(plainText);
        using SHA256 sha256Hash = SHA256.Create();

        var stream = new MemoryStream(data);
        byte[] bytes = await sha256Hash.ComputeHashAsync(stream);

        StringBuilder builder = new StringBuilder();

        foreach (var hashSegment in bytes)
        {
            builder.Append(hashSegment.ToString("x2"));
        }

        return builder.ToString();
    }
}