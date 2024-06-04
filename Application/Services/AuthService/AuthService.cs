using BusinessLogic.Interfaces.Services.AuthService;
using Models.SupabaseModels.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public async Task<string> Login(AdminLoginDto dto)
        {
            var url = "https://lbqpoifccgmqlsydhvke.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImxicXBvaWZjY2dtcWxzeWRodmtlIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTI2MDE4NDYsImV4cCI6MjAyODE3Nzg0Nn0.EkMkG3X1inJUPs0Y0_GFCnVBCidQ2VMtTlINCw3Xu8A";
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);
            var session= await supabase.Auth.SignIn(dto.Email, dto.Password);
            return session.RefreshToken;
        }

        public async Task<string> RefreshToken()
        {
            

            var url = "https://lbqpoifccgmqlsydhvke.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImxicXBvaWZjY2dtcWxzeWRodmtlIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTI2MDE4NDYsImV4cCI6MjAyODE3Nzg0Nn0.EkMkG3X1inJUPs0Y0_GFCnVBCidQ2VMtTlINCw3Xu8A";
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };
            return null;
        }

            public async Task Logout()
        {
            var url = "https://lbqpoifccgmqlsydhvke.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImxicXBvaWZjY2dtcWxzeWRodmtlIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTI2MDE4NDYsImV4cCI6MjAyODE3Nzg0Nn0.EkMkG3X1inJUPs0Y0_GFCnVBCidQ2VMtTlINCw3Xu8A";
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);
            await supabase.Auth.SignOut();
        }
    }
}
