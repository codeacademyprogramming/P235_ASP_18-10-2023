namespace P235FirstApi.DTOs.CategoriesDTOs
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public string Image { get; set; }

        public IEnumerable<CategoryChildDto>? Children { get; set; }
    }
}
