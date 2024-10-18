using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GameOfDrones.Infrastructure.Data.Interceptors;

public class DispatchDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly IMediator _mediator;

    public DispatchDomainEventsInterceptor(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        return base.SavingChanges(eventData, result);

    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
