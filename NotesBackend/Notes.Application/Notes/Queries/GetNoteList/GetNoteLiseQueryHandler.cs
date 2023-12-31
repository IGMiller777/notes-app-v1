using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteList;

public class GetNoteLiseQueryHandler : IRequestHandler<GetNoteListQuery, NoteListVm>
{
    private readonly INotesDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetNoteLiseQueryHandler(INotesDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
    {
        var notesQuery = await _dbContext.Notes
            .Where(note => note.UserId == request.UserId)
            .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new NoteListVm { Notes = notesQuery };
    }
}