using Complex.Common.Utility;
using Complex.Entity;
using Complex.ICO.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Logical.ILogical
{
    [ICOEnable(true)]
    public interface ILogin : ITransientLifetimeManagerRegister
    {
        bool IsLogin(test2 model,int aa,decimal bb,object cc ,float aaa);
      //  bool IsLogin(test2 model, int aa); 
    }
}
