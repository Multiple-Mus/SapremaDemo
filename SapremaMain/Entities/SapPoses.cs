using System;
using System.Collections.Generic;

namespace SapremaMain.Entities
{
    public partial class SapPoses
    {
        public SapPoses()
        {
            SapClassPoses = new HashSet<SapClassPoses>();
            SapUserPoses = new HashSet<SapUserPoses>();
        }

        public string PoseId { get; set; }
        public string PoseName { get; set; }
        public int PoseLevel { get; set; }
        public string PoseTheme { get; set; }

        public virtual ICollection<SapClassPoses> SapClassPoses { get; set; }
        public virtual ICollection<SapUserPoses> SapUserPoses { get; set; }
    }
}
