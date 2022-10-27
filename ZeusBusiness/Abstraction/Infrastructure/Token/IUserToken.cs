using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusBusiness.Abstraction.Infrastructure.Token
{
    public interface IUserToken
    {
        public Task RefreshToken();
    }
}
