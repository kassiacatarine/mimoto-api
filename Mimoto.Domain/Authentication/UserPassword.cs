using System;

namespace Mimoto.Domain.Common
{
    public class UserPassword
    {
        public string Password { get; private set; }
        public DateTime Creation { get; private set; }
        public DateTime Expiration { get; private set; }
    }
}