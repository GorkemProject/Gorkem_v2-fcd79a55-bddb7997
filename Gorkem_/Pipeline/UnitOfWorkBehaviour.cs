using Gorkem_.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Gorkem_.Pipeline
{
    public sealed class UnitOfWorkBehaviour<TRequest, TResponse>
          : IPipelineBehavior<TRequest, TResponse>
          where TRequest : notnull
    {

        private readonly GorkemDbContext _dbContext;

        public UnitOfWorkBehaviour(GorkemDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (!typeof(TRequest).Name.EndsWith("Command"))
            {
                return await next();
            }

            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var response = await next();
                try
                {
                    await _dbContext.SaveChangesAsync(cancellationToken);
               
                }
                catch (Exception)
                { 
                    // transactionscop hata alınması durumunda otomatik rollback yapıyor...
                }

                transactionScope.Complete();
                return response;
            }

        }
    }
}
