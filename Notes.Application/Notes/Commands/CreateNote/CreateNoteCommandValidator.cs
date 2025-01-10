using FluentValidation;

namespace Notes.Application.Notes.Commands.CreateNote;

public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
{
    private const int maxLengthTitle = 250;
    private const int maxLengthDetails = 1000;

    public CreateNoteCommandValidator()
    {
        RuleFor(createNoteCommand =>
                createNoteCommand.UserId)
                    .NotEqual(Guid.Empty);

        RuleFor(createNoteCommand =>
                createNoteCommand.Title)
                    .NotEmpty()
                    .MaximumLength(maxLengthTitle);

        RuleFor(createNoteCommand =>
                createNoteCommand.Details)
                    .NotEmpty()
                    .MaximumLength(maxLengthDetails);
    }
}