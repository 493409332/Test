/*
Author      : 张智
Date        : 2011-3-7
Description : 提供对类型、成员的描述功能
*/


using System;

namespace Complex.Common.Utility
{
    /// <summary>
    /// 提供对类型、成员的描述功能
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class DescriptionAttribute : System.Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="description">描述信息</param>
        public DescriptionAttribute(string description)
        {
            this.Description = description;
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description
        {
            get;
            set;
        }
    }
    /// <summary>
    ///ICO注册工厂提供允许注册的权限
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class ICOEnableAttribute : System.Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="description">是否允许</param>
        public ICOEnableAttribute(bool Enable)
        {
            this.Enable = Enable;
        }

        /// <summary>
        /// 是否允许
        /// </summary>
        public bool Enable
        {
            get;
            set;
        }
    }
}
