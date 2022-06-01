
using Microsoft.AspNetCore.Identity;

namespace Ipcam.Models
{
    public class IpcamUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
