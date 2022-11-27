namespace FSE.API.Application.Behaviors
{
    public class BusinessBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is AddProfileCommand)
            {
                var addCommand = request as AddProfileCommand;
                if (!addCommand.AssociateId.ToUpper().StartsWith("CTS"))
                {
                    addCommand.AssociateId = "CTS" + addCommand.AssociateId;
                }
            }
            if (request is UpdateProfileCommand)
            {
                var updateCommand = request as UpdateProfileCommand;
                if (!updateCommand.AssociateId.ToUpper().StartsWith("CTS"))
                {
                    updateCommand.AssociateId = "CTS" + updateCommand.AssociateId;
                }
            }
            return await next();
        }
    }
}
