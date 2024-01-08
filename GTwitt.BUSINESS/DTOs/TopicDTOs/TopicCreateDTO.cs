using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.DTOs.TopicDTOs
{
    public class TopicCreateDTO
    {
        public string Name { get; set; }
    }
    public class TopicCreateDTOValidator : AbstractValidator<TopicCreateDTO>
    {
        public TopicCreateDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(32);
        }
    }
}
