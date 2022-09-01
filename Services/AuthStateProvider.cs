using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinancesServer.Services
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public AuthStateProvider(ILocalStorageService storage)
        {
            _localStorage = storage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Not authenticated (empty claims)
            var state = new AuthenticationState(new ClaimsPrincipal());
            string username = "";
            string role = "";

            // Catching and ignoring InvalidOperationException
            // Exception is raised cause in pre-rendering phase we can not preform JavaScript interop calls (like getting data forom _localStorage)
            // Also I can not use OnAfterRenderAsync lifecycle method or skip pre-rendering for paths that require authorization cause whole program requres authorization
            try {
                username = await _localStorage.GetItemAsStringAsync("username");
            }
            catch {}

            try {
                role = await _localStorage.GetItemAsStringAsync("authLevel");
            }
            catch {}
            
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(role))
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                },  "Test auth");

                state = new AuthenticationState(new ClaimsPrincipal(identity));
            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }

    }
}