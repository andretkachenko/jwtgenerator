using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

CertArgs certArgs;

// Read configuration json, path to the .json file is expected to be passed as an argument
using (StreamReader r = new StreamReader(args[0]))
{
    string json = r.ReadToEnd();
    var serialized = JsonConvert.DeserializeObject<CertArgs>(json);
    if (serialized == null) throw new ArgumentException("invalid json");
    certArgs = serialized;
}

// read OpenSSL certificate
var certificate = new X509Certificate2(certArgs.CertificatePath, certArgs.Password);
var key = new X509SecurityKey(certificate, certArgs.Password);

// fill JWT claims
// "alg" header will be added automatically
var tokenHandler = new JwtSecurityTokenHandler();
var tokenDescriptor = new SecurityTokenDescriptor
{
    Issuer = certArgs.Issuer,
    Audience = certArgs.Audience,
    Subject = new ClaimsIdentity(new Claim[] { new Claim("sub", certArgs.Subject) }),
    Expires = DateTime.UtcNow.AddDays(7),
    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256)
};

// sign and serialize token
var token = tokenHandler.CreateToken(tokenDescriptor);
var tokenString = tokenHandler.WriteToken(token);

// show the token 
Console.WriteLine("Your token:");
Console.WriteLine(tokenString);

class CertArgs
{
    [JsonProperty("pwd")]
    public required string Password { get; set; }

    [JsonProperty("crt")]
    public required string CertificatePath { get; set; }

    [JsonProperty("iss")]
    public required string Issuer { get; set; }

    [JsonProperty("aud")]
    public required string Audience { get; set; }

    [JsonProperty("sub")]
    public required string Subject { get; set; }

    public CertArgs()
    {
        Password = string.Empty;
        CertificatePath = string.Empty;
        Issuer = string.Empty;
        Audience = string.Empty;
        Subject = string.Empty;
    }
}