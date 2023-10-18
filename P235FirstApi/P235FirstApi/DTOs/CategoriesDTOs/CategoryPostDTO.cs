using FluentValidation;
using Microsoft.EntityFrameworkCore;
using P235FirstApi.DataAccesslayer;

namespace P235FirstApi.DTOs.CategoriesDTOs
{
    /// <summary>
    /// Categorya Create Model
    /// </summary>
    public class CategoryPostDTO
    {
        /// <summary>
        /// Category Name
        /// </summary>
        public string Ad { get; set; }
        /// <summary>
        /// Category When True Image Requiered else ParentId Required
        /// </summary>
        public bool Esasdir { get; set; }
        public int? UstCategoryId { get; set; }
        public IFormFile? file { get; set; }
    }

    /// <summary>
    /// Validator
    /// </summary>
    public class CategoryPostDTOValidator : AbstractValidator<CategoryPostDTO>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_context"></param>
        public CategoryPostDTOValidator(AppDbContext _context)
        {
            RuleFor(r => r.Ad)
                .NotEmpty().WithMessage("Mutleq Name Daxil Edilmelidir")
                .MinimumLength(3).WithMessage("Minimum 3 simvol Ola Biler")
                .MaximumLength(100).WithMessage("Maksimum 100 Simvol Ola Biler");

            RuleFor(r => r).Custom((r, context) =>
            {
                if (_context.Categories.Any(c => c.IsDeleted == false && c.Name.ToLower() == r.Ad.Trim().ToLower()))
                {
                    context.AddFailure(nameof(CategoryPostDTO.Ad), "Already Exist");
                }

                if (r.Esasdir)
                {
                    if(r.file == null)
                    {
                        context.AddFailure(nameof(CategoryPostDTO.file), "Image Is Required");
                    }

                    if (r.file?.ContentType != "image/jpeg")
                    {
                        context.AddFailure(nameof(CategoryPostDTO.file), "Image Is incorrect type");
                    }

                    r.UstCategoryId = null;
                }
                else
                {
                    if (!_context.Categories.Any(c => c.IsDeleted == false && c.IsMain == true && c.Id == r.UstCategoryId))
                    {
                        context.AddFailure(nameof(CategoryPostDTO.UstCategoryId), "InCorrect Parent Id");
                    }
                }
            });
        }
    }
}
