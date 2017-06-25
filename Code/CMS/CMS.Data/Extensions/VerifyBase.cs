using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data
{
    [AttributeUsage(AttributeTargets.All)]

    public class VerifyAttribute : Attribute
    {
        private CMS.Code.Enums.VerifyType[] _attrs;

        public VerifyAttribute(params CMS.Code.Enums.VerifyType[] attrs)
        {
            _attrs = attrs;
        }
        public CMS.Code.Enums.VerifyType[] Verify { get { return _attrs; } }
    }
    [AttributeUsage(AttributeTargets.All)]

    public class VerifyHasMsgAttribute : Attribute
    {
        private Dictionary<CMS.Code.Enums.VerifyType, string> _attrs;

        public VerifyHasMsgAttribute(Dictionary<CMS.Code.Enums.VerifyType, string> attrs)
        {
            _attrs = attrs;
        }
        public Dictionary<CMS.Code.Enums.VerifyType, string> VerifyHasMsg { get { return _attrs; } }
    }
}
