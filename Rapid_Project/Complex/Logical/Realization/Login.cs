using Complex.Common.Utility;
using Complex.Entity;
using Complex.Logical.AopAttribute;
using Complex.Logical.ILogical;
using Complex.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Logical.Realization
{
    [Description("Login")]
    public class Login : EFRepositoryBase<test2>, ILogin
    {
        public Login() {
            ChangeDatabase("MySqlCompact");
        }
        int ii = 1;
        //[Start]
        //[Ex]
        //public bool IsLogin(test2 model)
        //{ 
        //    ii = 2; 
        //    Insert(model);  
        //    return false;
        //}

        #region ILogin 成员


         [Start1]
        public bool IsLogin(test2 model, int aa, decimal bb, object cc, float aaa)
     //   public bool IsLogin(test2 model, int aa)
        {
            Insert(model);
            //Update(model);
            ii = aa;
           // Insert(model);
            return false;
        }

        #endregion
    }
}
