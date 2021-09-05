namespace Core.Entity.Abstract
{
    public interface ISoftDeleted
    {
        public bool IsDeleted { get; set; }
    }
}