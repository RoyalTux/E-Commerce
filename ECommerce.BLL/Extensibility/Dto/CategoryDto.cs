namespace ECommerce.BLL.Extensibility.Dto
{
    public class CategoryDto
    {
        public CategoryDto()
        {
            Id = -1;
            ParentId = -1;
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }
    }
}
