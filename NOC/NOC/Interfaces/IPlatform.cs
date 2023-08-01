using System;
using Microsoft.Identity.Client;

namespace NOC.Interfaces
{
    public interface IPlatform
    {
        IPublicClientApplication GetIdentityClient(string applicationId);
    }
}
