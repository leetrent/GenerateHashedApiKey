using System.Security.Cryptography;
using System.Text;

Console.WriteLine("Calling GenerateApiKey()");
string generatedApiKey = GenerateApiKey();
Console.WriteLine("Returning from GenerateApiKey()");
Console.WriteLine($"(generatedApiKey): '{generatedApiKey}'");

string GenerateApiKey()
{
    // Create a new GUID.
    string apiKey = Guid.NewGuid().ToString();
    Console.WriteLine($"(apiKeyString): '{apiKey}'");

    // Convert the API key to a byte array.
    byte[] apiKeyBytes = Encoding.UTF8.GetBytes(apiKey);
    Console.WriteLine($"(apiKeyBytes): '{apiKeyBytes}'");

    // Use the SHA256 algorithm to hash the API key.
    using (SHA256 sha256Hash = SHA256.Create())
    {
        byte[] hashBytes = sha256Hash.ComputeHash(apiKeyBytes);
        Console.WriteLine($"(hashBytes): '{hashBytes}'");

        // Convert the byte array to a string.
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            builder.Append(hashBytes[i].ToString("x2"));
        }

        return builder.ToString();
    }
}


