namespace FSE.Admin.API.Application.Behaviors
{
    public class BusinessBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
          where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is SearchProfileQuery)
            {
                var searchQuery = request as SearchProfileQuery;
                if (!string.IsNullOrEmpty(searchQuery.AssociateId) &&
                    !searchQuery.AssociateId.ToUpper().StartsWith("CTS"))
                {
                    searchQuery.AssociateId = "CTS" + searchQuery.AssociateId;
                }
            }
            return await next();
        }
    }

}
