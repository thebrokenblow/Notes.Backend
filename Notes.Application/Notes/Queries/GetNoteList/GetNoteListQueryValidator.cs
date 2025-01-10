using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteList;

public class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>
{
    public GetNoteListQueryValidator()
    {
        RuleFor(noteList => 
                    noteList.UserId)
                        .NotEqual(Guid.Empty);
    }
}