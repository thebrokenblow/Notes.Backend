using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteList;

public class GetNoteRangeQueryValidator : AbstractValidator<GetNoteRangeQuery>
{
    public GetNoteRangeQueryValidator()
    {
        RuleFor(noteList => 
                    noteList.UserId)
                        .NotEqual(Guid.Empty);
    }
}