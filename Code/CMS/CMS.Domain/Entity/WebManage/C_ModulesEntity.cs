using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.WebManage
{
    public class C_ModulesEntity : IEntity<C_ModulesEntity>
    {
        public string C_ID { get; set; }
        public string C_Name { get; set; }
        public int C_Type { get; set; }
        public string C_ActionName { get; set; }
        public string C_Desc { get; set; }
        public string C_Url { get; set; }
        public string C_Icon { get; set; }
        public bool C_IsUse { get; set; }
        public bool C_IsDelete { get; set; }
        public string C_CreateUserID { get; set; }
        public DateTime? C_CreateTime { get; set; }
        public string C_DeleteUserID { get; set; }
        public DateTime? C_DeleteTime { get; set; } 
    }
}
