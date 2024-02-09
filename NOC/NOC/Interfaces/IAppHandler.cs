using System;
using System.Threading.Tasks;

namespace NOC.Interfaces
{
    public interface IAppHandler
    {
        Task<bool> LaunchApp(string packageName);
    }
}
