using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.DTOs.PostDTOs
{
    public class PostUpdateDTO
    {
        public string Text { get; set; }
        public int? UserId { get; set; }
    }
    public class PostUpdateDTOValidator : AbstractValidator<PostUpdateDTO>
    {
        public PostUpdateDTOValidator()
        {
            RuleFor(x => x.Text).NotEmpty().MaximumLength(1014);
        }
    }
}
