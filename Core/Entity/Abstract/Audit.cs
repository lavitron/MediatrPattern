using System;

namespace Core.Entity.Abstract
{
    public class Audit
    {
        public int CUserId { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public int? MUserId { get; set; }
        public DateTime? MDate { get; set; }
    }
}