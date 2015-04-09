using Complex.Common.Utility;
using Complex.Entity;
using Complex.Logical.AopAttribute;
using Complex.Logical.ILogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Logical.Realization
{
    [Description("Login1")]
    public class Login1 : ILogin
    {
        int ii = 1;
    
        //[Start]
        //public bool IsLogin(test2 model)
        //{
        //    ii = 2;
          
        //    return false;
        //}

        #region ILogin 成员
         
         [Start1]
        public bool IsLogin(test2 model, int aa, decimal bb, object cc, float aaa)
      //  public bool IsLogin(test2 model, int aa)
        {
            ii = 2;

            return false;
        }

        #endregion
    }
}
