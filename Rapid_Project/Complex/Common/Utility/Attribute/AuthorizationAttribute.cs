using Complex.BLL;
using Complex.Common.Cache;
using Complex.Entity;
using Complex.Entity.CurrentUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Complex.Common.Utility.Attribute
{
    /// <summary>
    /// 表示需要用户登录才可以使用的特性
    /// <para>如果不需要处理用户登录，则请指定AllowAnonymousAttribute属性</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {

        string PurviewName;
        public AuthorizationAttribute(string purviewtype)
        {
            if (purviewtype != null)
            {
                PurviewName = purviewtype;
            }
        }

        /// <summary>
        /// 处理用户登录
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            //watch.Start();
             CurrentUserInfo model=null;



            //if (filterContext.HttpContext.Session["userinfo"] != null)
            //{
            //    UserCenter modelUserCenter = (UserCenter)filterContext.HttpContext.Session["userinfo"];

            //    if (modelUserCenter.UserID != null)
            //    {
            //        BUserBelong buserblong = new BUserBelong();
            //        UserBelong mUserBelong = buserblong.GetModelById(modelUserCenter.UserBelongID != null ? Convert.ToInt32(modelUserCenter.UserBelongID) : 0);
            //        BPurview bpurview = new BPurview();
            //        Purview mPurview = bpurview.GetModelByPurviewType(mUserBelong.BelongType);
            //        model = new CurrentUserInfo();
            //        model.UserCenter = modelUserCenter;
            //        model.UserBelong = mUserBelong;
            //        model.Purview = mPurview;
                    
            //    }
            //}
            //else if (filterContext.HttpContext.Request.Cookies["user"] != null)
            //{
            //    if (filterContext.HttpContext.Request.Cookies["user"].Values["userid"] != null)
            //    {
            //        BUserCenter busercenter = new BUserCenter();
            //        UserCenter modelUserCenter = busercenter.GetmodelById(Convert.ToInt32(filterContext.HttpContext.Request.Cookies["user"].Values["userid"]));

            //        if (modelUserCenter.UserID != null)
            //        {
            //            BUserBelong buserblong = new BUserBelong();
            //            UserBelong mUserBelong = buserblong.GetModelById(modelUserCenter.UserBelongID != null ? Convert.ToInt32(modelUserCenter.UserBelongID) : 0);
            //            BPurview bpurview = new BPurview();
            //            Purview mPurview = bpurview.GetModelByPurviewType(mUserBelong.BelongType);
            //            model = new CurrentUserInfo();
            //            model.UserCenter = modelUserCenter;
            //            model.UserBelong = mUserBelong;
            //            model.Purview = mPurview;
         
            //        }
            //    }
            //}

            #region 

            if (filterContext.HttpContext.Session["userinfo"] != null)
            {

                UserCenter modelUserCenter = (UserCenter)filterContext.HttpContext.Session["userinfo"];

                if (modelUserCenter.UserID != 0)
                {
                    object CurrentUserInfoobj = DataCache.GetCache(modelUserCenter.UserID.ToString());
                    if (CurrentUserInfoobj != null)
                    {
                        model = (CurrentUserInfo)CurrentUserInfoobj;
                    }
                    else
                    {
                        BUserBelong buserblong = new BUserBelong();
                        UserBelong mUserBelong = buserblong.GetModelById(modelUserCenter.UserBelongID != null ? Convert.ToInt32(modelUserCenter.UserBelongID) : 0);
                        BPurview bpurview = new BPurview();
                        Purview mPurview = bpurview.GetModelByPurviewType(mUserBelong.BelongType);
                        model = new CurrentUserInfo();
                        model.UserCenter = modelUserCenter;
                        model.UserBelong = mUserBelong;
                        model.Purview = mPurview;
                        DataCache.SetCache(modelUserCenter.UserID.ToString(), model);

                    }
                }
            }
            else if (filterContext.HttpContext.Request.Cookies["user"] != null)
            {
                if (filterContext.HttpContext.Request.Cookies["user"].Values["userid"] != null)
                {
                    BUserCenter busercenter = new BUserCenter();
                    UserCenter modelUserCenter = busercenter.GetmodelById(Convert.ToInt32(filterContext.HttpContext.Request.Cookies["user"].Values["userid"]));
                    filterContext.HttpContext.Session["userinfo"] = modelUserCenter;
                    if (filterContext.HttpContext.Request.Cookies["user"].Values["userid"] != null)
                    {
                        object CurrentUserInfoobj = DataCache.GetCache(filterContext.HttpContext.Request.Cookies["user"].Values["userid"].ToString());
                        if (CurrentUserInfoobj != null)
                        {
                            model = (CurrentUserInfo)CurrentUserInfoobj;
                        }
                        else
                        {
                            BUserBelong buserblong = new BUserBelong();
                            UserBelong mUserBelong = buserblong.GetModelById(modelUserCenter.UserBelongID != null ? Convert.ToInt32(modelUserCenter.UserBelongID) : 0);
                            BPurview bpurview = new BPurview();
                            Purview mPurview = bpurview.GetModelByPurviewType(mUserBelong.BelongType);
                            model = new CurrentUserInfo();
                            model.UserCenter = modelUserCenter;
                            model.UserBelong = mUserBelong;
                            model.Purview = mPurview;
                            DataCache.SetCache(modelUserCenter.UserID.ToString(), model);

                        }
                    }
                }
            }
            #endregion

            //watch.Stop();
            ////获取当前实例测量得出的总运行时间（以毫秒为单位）
            //string time = watch.ElapsedMilliseconds.ToString();
            string PurviewType;

            switch (PurviewName)
            {
                case "管理员":
                    PurviewType = "1";
                    break;
                case "网格员":
                    PurviewType = "2";
                    break;
                case "街办（乡镇）管理员":
                    PurviewType = "3";
                    break;
                case "社区管理员":
                    PurviewType = "4";
                    break;
                case "志愿者":
                    PurviewType = "5";
                    break;
                case "农村管理员":
                    PurviewType = "6";
                    break;
                case "农村市管理员":
                    PurviewType = "7";
                    break;
                case "农村镇管理员":
                    PurviewType = "8";
                    break;
                case "农村组管理员":
                    PurviewType = "9";
                    break;
                case "农村志愿者":
                    PurviewType = "10";
                    break;
                case "农村村管理员":
                    PurviewType = "11";
                    break;
                case "督办":
                    PurviewType = "12";
                    break;
                case "部门":
                    PurviewType = "17";
                    break;
                case "登录":
                    PurviewType = "登录";
                    break;
                default:
                    PurviewType = "未传入权限";
                    break;
            }

            if (model == null)
            {
                filterContext.Result = new RedirectResult("/UserLogin/Index", false);
                return;
            }
            if (model != null)
            {
                if (PurviewType == "登录")
                {
                      return;
                }
                if (model.Purview.PurviewType.Trim() != PurviewType || model.Purview.PurviewName.Trim() != PurviewName || model.UserBelong.BelongType.Trim() != PurviewType)
                {
                    filterContext.Result = new RedirectResult("/UserLogin/Index", false);
                }
            }
        }
    }
}
