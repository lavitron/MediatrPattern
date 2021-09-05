using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class CoreEntity : Audit, ISoftDeleted
    {
        public bool IsDeleted { get; set; }
    }
}