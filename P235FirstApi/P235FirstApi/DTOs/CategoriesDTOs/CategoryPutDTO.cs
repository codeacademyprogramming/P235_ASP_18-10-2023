using FluentValidation;
using P235FirstApi.DataAccesslayer;

namespace P235FirstApi.DTOs.CategoriesDTOs
{
    public class CategoryPutDTO
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public IFormFile? Image { get; set; }
        public int? ParentId { get; set; }

    }

    public class CategoryPutDTOValidator : AbstractValidator<CategoryPutDTO>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_context"></param>
        public CategoryPutDTOValidator(AppDbContext _context)
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Mutleq Name Daxil Edilmelidir")
                .MinimumLength(3).WithMessage("Minimum 3 simvol Ola Biler")
                .MaximumLength(100).WithMessage("Maksimum 100 Simvol Ola Biler");

            RuleFor(r => r).Custom((r, context) =>
            {
                if (_context.Categories.Any(c => c.IsDeleted == false && c.Name.ToLower() == r.Name.Trim().ToLower()))
                {
                    context.AddFailure(nameof(CategoryPutDTO.Name), "Already Exist");
                }

                if (r.IsMain)
                {
                    if (r.Image == null)
                    {
                        context.AddFailure(nameof(CategoryPutDTO.Image), "Image Is Required");
                    }

                    if (r.Image?.ContentType != "image/jpeg")
                    {
                        context.AddFailure(nameof(CategoryPutDTO.Image), "Image Is incorrect type");
                    }

                    r.ParentId = null;
                }
                else
                {
                    if (!_context.Categories.Any(c => c.IsDeleted == false && c.IsMain == true && c.Id == r.ParentId))
                    {
                        context.AddFailure(nameof(CategoryPostDTO.UstCategoryId), "InCorrect Parent Id");
                    }
                }
            });
        }
    }
}
