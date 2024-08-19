using FluentValidation;

namespace PSManagement.Application.Projects.UseCases.Commands.AddAttachment
{
    public class AddAttachmentCommandValidator : AbstractValidator<AddAttachmentCommand>
    {
        public AddAttachmentCommandValidator()
        {
            RuleFor(x => x.AttachmentDescription)
                .NotEmpty()
                .MinimumLength(15);
            RuleFor(x => x.AttachmentName)
                .NotEmpty()
                .MinimumLength(5);
           
        }
    }
}
