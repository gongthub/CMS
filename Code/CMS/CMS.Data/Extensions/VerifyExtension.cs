using CMS.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Extensions
{
    public class VerifyExtension
    {

        public static void Verity<T>(T entity)
        {
            var type = typeof(T);
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                Object[] attrs = prop.GetCustomAttributes(true);
                string strDesc = string.Empty;
                DescriptionAttribute descAttr = Attribute.GetCustomAttribute(prop, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (descAttr != null)
                {
                    strDesc = descAttr.Description;
                }
                foreach (Object verify in attrs)
                {
                    if (verify is VerifyAttribute)
                    {
                        CMS.Code.Enums.VerifyType[] Verifys = (verify as VerifyAttribute).Verify;
                        if (Verifys != null && Verifys.Length > 0)
                        {
                            foreach (var Verify in Verifys)
                            {
                                object val = entity.GetType().GetProperty(prop.Name).GetValue(entity, null);
                                VerityEntity(Verify, val, strDesc);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 当个字段合法性校验
        /// </summary>
        /// <param name="Verifys"></param>
        /// <param name="val"></param>
        /// <param name="desc"></param>
        private static void VerityEntity(CMS.Code.Enums.VerifyType Verifys, object val, string desc)
        {
            switch (Verifys)
            {
                case Enums.VerifyType.IsNull:
                    if (val == null)
                    {
                        throw new Exception("字段 '" + desc + "'不能为空！");
                    }
                    break;
                case Enums.VerifyType.IsNullOrEmpty:
                    if (val == null || string.IsNullOrEmpty(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'不能为空！");
                    }
                    break;
                case Enums.VerifyType.IsInt:
                    if (val != null && !Code.Validate.IsNumber(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'只能为数字！");
                    }
                    break;
                case Enums.VerifyType.IsIdCard:
                    if (val != null && !Code.Validate.IsIdCard(val.ToString()))
                    {
                        throw new Exception("身份证格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsEmail:
                    if (val != null && !Code.Validate.IsEmail(val.ToString()))
                    {
                        throw new Exception("邮箱格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsPhone:
                    if (val != null && !Code.Validate.IsValidPhoneAndMobile(val.ToString()))
                    {
                        throw new Exception("手机号格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsUrl:
                    if (val != null && !Code.Validate.IsValidURL(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsIP:
                    if (val != null && !Code.Validate.IsValidIP(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsDomain:
                    if (val != null && !Code.Validate.IsValidDomain(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsDomainOrEmpty:
                    if (val != null && !string.IsNullOrEmpty(val.ToString()) && !Code.Validate.IsValidDomain(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsGuid:
                    if (!Code.Validate.IsGuid(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsDate:
                    if (val != null && !string.IsNullOrEmpty(val.ToString()) && !Code.Validate.IsDate(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsDomainOrIP:
                    if (val != null && !string.IsNullOrEmpty(val.ToString()) && !(Code.Validate.IsValidDomain(val.ToString()) || !Code.Validate.IsValidIP(val.ToString())))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
                case Enums.VerifyType.IsNullOrGuid:
                    if (val != null && !string.IsNullOrEmpty(val.ToString()) && !Code.Validate.IsGuid(val.ToString()))
                    {
                        throw new Exception("字段 '" + desc + "'格式不正确！");
                    }
                    break;
            }
        }
    }
}
