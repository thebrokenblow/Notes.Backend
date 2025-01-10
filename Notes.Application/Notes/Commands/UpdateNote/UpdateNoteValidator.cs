using FluentValidation;

namespace Notes.Application.Notes.Commands.UpdateNote;

public class UpdateNoteValidator : AbstractValidator<UpdateNoteCommand>
{
    private const int maxLengthTitle = 250;
    private const int maxLengthDetails = 1000;

    public UpdateNoteValidator()
    {
        RuleFor(updateNoteCommand => 
                updateNoteCommand.UserId)
                    .NotEqual(Guid.Empty);

        RuleFor(updateNoteCommand =>
                updateNoteCommand.Id)
                    .NotEqual(Guid.Empty);

        RuleFor(updateNoteCommand =>
                updateNoteCommand.Title)
                    .NotEmpty()
                    .MaximumLength(maxLengthTitle);

        RuleFor(updateNoteCommand =>
                updateNoteCommand.Details)
                    .NotEmpty()
                    .MaximumLength(maxLengthDetails);
    }
}