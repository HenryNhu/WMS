using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class RoleBasePermission
    {
        public int RoleId { get; set; }
        public long UserId { get; set; }
        public bool AccessWebsite { get; set; }
        public bool AccessMobile { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
