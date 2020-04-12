using NetCoreWebAPI.Entities;

namespace NetCoreWebAPI
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}