using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Complex.Entity;
using Complex.Logical.ILogical;
using Complex.Logical.Realization;
using MtAop.BaseAttribute;
using MtAop.Context;

namespace MvcWeb.Controllers
{
    public class Default2Controller : Controller
    {
        //
        // GET: /Default2/

        public ActionResult Index()
        {
           // bool aa =new DynamicLoginType().IsLogin(new test2() { ID = 1, Name = "12", Num = 1, test3 = new test3() { Name1 = "123", Num1 = 1 } }, 11, 1.11m, 111, 1.1123f);
            return View();
        }

    }
    //public sealed class DynamicLoginType : ILogin
    //{
    //    // Fields
    //    private Login _realProxy = null;

    //    // Methods
    //    public DynamicLoginType()
    //    {
    //        this._realProxy = new Login();
    //    }

    //    public   bool IsLogin(test2 test1, int num1, decimal decimal1, object obj1, float single1)
    //    {
    //        InvokeContext context = new InvokeContext();
    //        context.SetMethod("IsLogin");
    //        bool result = (bool) Activator.CreateInstance(Type.GetType("System.Boolean"));
    //        Exception e = null;
    //        context.SetParameter(test1);
    //        context.SetParameter(num1);
    //        context.SetParameter(decimal1);
    //        context.SetParameter(obj1);
    //        context.SetParameter(single1);
    //        bool flag2 = true;
    //        MethodInfo method = this._realProxy.GetType().GetMethod("IsLogin");
    //        PreAspectAttribute customAttribute = (PreAspectAttribute) Attribute.GetCustomAttribute(method, typeof(PreAspectAttribute));
    //        if ( customAttribute != null )
    //        {
    //            context = customAttribute.Action(context);
    //        }
    //        if ( !context.IsRun )
    //        {
    //            return (bool) Activator.CreateInstance(Type.GetType("System.Boolean"));
    //        }
    //        try
    //        {
    //            result = this._realProxy.IsLogin((test2) context.Parameters[0], (int) context.Parameters[1], (decimal) context.Parameters[2], context.Parameters[3], (float) context.Parameters[4]);
    //            context.SetResult(result);
    //            PostAspectAttribute attribute2 = (PostAspectAttribute) Attribute.GetCustomAttribute(method, typeof(PostAspectAttribute));
    //            if ( attribute2 != null )
    //            {
    //                 attribute2.Action(context);
    //            }
    //        }
    //        catch ( Exception exception1 )
    //        {
    //            e = exception1;
    //            context.SetError(e);
    //            ExceptionAspectAttribute attribute3 = (ExceptionAspectAttribute) Attribute.GetCustomAttribute(method, typeof(ExceptionAspectAttribute));
    //            if ( attribute3 != null )
    //            {
    //                attribute3.Action(context);
    //            }
    //        }
    //        return result;
    //    }
    //}

 

}
