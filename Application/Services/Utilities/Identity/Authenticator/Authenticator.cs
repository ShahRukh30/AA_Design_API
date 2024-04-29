using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services.Utilites;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Utilities.Identity.Authenticator
{
    public class Authenticator 
    {
        //private readonly IUserRepository _userepo;
        //private readonly IConfiguration _config;
        //public Authenticator(IUserRepository userepo, IConfiguration config)
        //{
        //    _userepo = userepo;
        //    _config = config;
        //}
        //public async Task<bool> Verification(LoginDto dto)
        //{
        //    User1 u = await _userepo.GetCred(dto);
        //    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Passwordhash, u.Passwordhash);
        //    return isPasswordValid;
        //}

        //public async Task<object> Tokenization( LoginDto actualuser)
        //{
           
        //    bool isvalid = await Verification(actualuser);


        //    if (isvalid)
        //    {
        //        User1 user = await _userepo.GetCred(actualuser);
        //        var config = _config.GetSection("Jwt");
        //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Key"]!));
        //        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        //        List<Claim> claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.Userid.ToString()),
        //        new Claim(ClaimTypes.Role, "Customer"),
        //        new Claim(ClaimTypes.Email, user.Email),
        //    };
        //        var token = new JwtSecurityToken(
        //            claims: claims,
        //            audience: config["Audience"],
        //            issuer: config["Issuer"],
        //            expires: DateTime.Now.AddMinutes(5),
        //            signingCredentials: cred
        //            );
        //        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        //        return jwt;
        //    }
        //    else
        //    {
        //        return "Password is Invalid";
        //    }

        //}
        //public string GenerateRefreshToken()
        //{
        //    var randomNumber = new byte[32];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(randomNumber);
        //        return Convert.ToBase64String(randomNumber);
        //    }
        //}

        //public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        //{
        //    var tokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateAudience = false, 
        //        ValidateIssuer = false,
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Key"]!)),
        //        ValidateLifetime = false 
        //    };
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    SecurityToken securityToken;
        //    var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        //    var jwtSecurityToken = securityToken as JwtSecurityToken;
        //    if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        //        throw new SecurityTokenException("Invalid token");
        //    return principal;
        //}


    }
}
