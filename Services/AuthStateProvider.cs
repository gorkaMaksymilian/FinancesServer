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

            // Catching and ignoring InvalidOperationException
            // Exception is raised cause in pre-rendering phase we can not preform JavaScript interop calls (like getting data forom _localStorage)
            // Also I can not use OnAfterRenderAsync lifecycle method or skip pre-rendering for paths that require authorization cause whole program requres authorization
            try {
                username = await _localStorage.GetItemAsStringAsync("username");
            }
            catch {}
            
            if (!string.IsNullOrEmpty(username))
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                },  "Test auth");

                state = new AuthenticationState(new ClaimsPrincipal(identity));
            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }

    }
}