using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteDetails;

public class GetNoteDetailsQueryValidator : AbstractValidator<GetNoteDetailsQuery>
{
    public GetNoteDetailsQueryValidator()
    {
        RuleFor(noteDetails => 
                    noteDetails.Id)
                        .NotEqual(Guid.Empty);

        RuleFor(noteDetails => 
                    noteDetails.UserId)
                        .NotEqual(Guid.Empty);
    }
}