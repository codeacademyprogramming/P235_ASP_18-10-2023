namespace P235FirstApi.DTOs.CategoriesDTOs
{
    public class CategoryListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int ChildrenCount { get; set; }
    }
}
