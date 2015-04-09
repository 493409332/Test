using MtAop.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtAop.Context
{
    /// <summary>
    /// 所有元数据
    /// </summary>
    public class InvokeContext
    {

        //List<ParameterMetadata> _parameters;
        List<object> _parameters=new List<object>();

        bool _IsRun = true;
        /// <summary>
        /// 是否继续运行
        /// </summary>
        public bool IsRun
        {
            get { return _IsRun; }
            set { _IsRun = value; }
        }
       
       
        /// <summary>
        /// 参数元数据
        /// </summary>
        //public ParameterMetadata[] Parameters
        //{
        //    get
        //    {
        //        if (_parameters != null)
        //        {
        //            return _parameters.ToArray();
        //        }

        //        return null;
        //    }
        //}
        public List<object> Parameters
        {
            get
            {
                if ( _parameters != null )
                {
                    return _parameters;
                }

                return null;
            }
        }
        MethodMetadata _method;
        /// <summary>
        /// 方法元数据
        /// </summary>
        public MethodMetadata Method
        {
            get
            {

                return _method;
            }
        }

        ResultMetadata _result;
        /// <summary>
        /// 返回元数据
        /// </summary>
        public ResultMetadata Result
        {
            get
            {
                return _result;
            }
        }

        ExceptionMetadata _ex;
        /// <summary>
        /// 异常元数据
        /// </summary>
        public ExceptionMetadata Ex
        {
            get
            {
                return _ex;
            }
        }


        /// <summary>
        /// 添加参数元数据
        /// </summary>
        /// <param name="parameter"></param>
        public void SetParameter(object parameter)
        { 
            _parameters.Add(parameter);
        }
        /// <summary>
        /// 添加异常元数据
        /// </summary>
        /// <param name="e"></param>
        public void SetError(Exception e)
        {
            _ex = new ExceptionMetadata(e);
        }
        /// <summary>
        /// 添加返回元数据
        /// </summary>
        /// <param name="result"></param>
        public void SetResult(object result)
        {
            _result = new ResultMetadata(result);
        }
        /// <summary>
        /// 添加方法元数据
        /// </summary>
        /// <param name="methodName"></param>
        public void SetMethod(string methodName)
        {
            _method = new MethodMetadata(methodName);
        }

    }
}
