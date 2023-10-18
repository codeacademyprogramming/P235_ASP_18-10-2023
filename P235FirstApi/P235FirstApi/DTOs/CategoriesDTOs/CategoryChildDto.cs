namespace P235FirstApi.DTOs.CategoriesDTOs
{
    public class CategoryChildDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
