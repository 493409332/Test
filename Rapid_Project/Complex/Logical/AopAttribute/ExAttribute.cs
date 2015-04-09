using MtAop.BaseAttribute;
using MtAop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Logical.AopAttribute
{
    class ExAttribute : ExceptionAspectAttribute
    {
        public override InvokeContext Action(InvokeContext context)
        {
            Console.WriteLine("log exception!");

            throw context.Ex.Ex;
        
        }
    }
}
