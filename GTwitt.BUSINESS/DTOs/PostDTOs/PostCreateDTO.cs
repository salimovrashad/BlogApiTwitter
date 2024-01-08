using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.DTOs.PostDTOs
{
    public class PostCreateDTO
    {
        public string Text { get; set; }
        public int? UserId { get; set; }
    }
    public class PostCreateDTOValidator : AbstractValidator<PostCreateDTO>
    {
        public PostCreateDTOValidator() 
        {
            RuleFor(x => x.Text).NotEmpty().MaximumLength(1014);
        }
    }
}
