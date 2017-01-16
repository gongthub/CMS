/*
 判断帮助类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Code
{
    public class JudgmentHelp
    {
        #region 单例模式创建对象
        //单例模式创建对象
        private static JudgmentHelp _judgmentHelp = null;
        // Creates an syn object.
        private static readonly object SynObject = new object();
        JudgmentHelp()
        {
        }

        public static JudgmentHelp judgmentHelp
        {
            get
            {
                // Double-Checked Locking
                if (null == _judgmentHelp)
                {
                    lock (SynObject)
                    {
                        if (null == _judgmentHelp)
                        {
                            _judgmentHelp = new JudgmentHelp();
                        }
                    }
                }
                return _judgmentHelp;
            }
        }
        #endregion

        /// <summary>
        /// 判断Guid字符串是否为空
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool IsNullOrEmptyOrGuidEmpty(string Ids)
        {
            bool retState = false;
            if (!string.IsNullOrEmpty(Ids))
            {
                Guid Id = Guid.Empty;
                if (Guid.TryParse(Ids, out Id) && Guid.Empty.ToString() != Ids)
                {
                    retState = true;
                }
            }
            return retState;
        }

        /// <summary>
        /// 判断Guid是否为空
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool IsNullOrGuidEmpty(Guid Id)
        {
            bool retState = false;
            if (Id != null && Id != Guid.Empty)
            {
                retState = true;
            }
            return retState;
        }

        /// <summary>
        /// 判断实体是否为空
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool IsNullEntity<T>(T t)
        {
            bool retState = false;
            if (t!=null)
            {
                retState = true;
            }
            return retState;
        }

    }
}
