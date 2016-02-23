namespace SimilarBeads.Web.Infrastructure.IdentityExtensions
{
    using System;
    using System.Security.Claims;
    using System.Security.Principal;

    public static class IdentityExtensions
    {
        public static bool IsAdmin(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("IsAdmin");
            return claim == null ? false : Convert.ToBoolean(claim.Value);
        }

        public static bool IsArtist(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("IsArtist");
            return claim == null ? false : Convert.ToBoolean(claim.Value);
        }

        public static string NameName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Name");
            return claim.Value;
        }
    }
}
