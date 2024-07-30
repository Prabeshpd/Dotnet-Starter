using System.Reflection;
using PetStore.Application.Common.Exceptions;
using PetStore.Application.Common.Interfaces;
using PetStore.Application.Common.Security;

namespace PetStore.Application.Common.Behaviors;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IUser _user;
    private readonly IIdentityService _identityService;

    public AuthorizationBehavior(
        IUser user,
        IIdentityService identityService)
    {
        _user = user;
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        IEnumerable<AuthorizeAttribute>? authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        if (authorizeAttributes.Any())
        {
            if (_user.Id == null)
            {
                throw new UnauthorizedAccessException();
            }

            IEnumerable<AuthorizeAttribute>? authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

            if (authorizeAttributesWithRoles.Any())
            {
                var authorized = false;

                foreach (string[] roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
                {
                    foreach (string role in roles)
                    {
                        bool isInRole = await _identityService.IsInRoleAsync(_user.Id, role.Trim());
                        if (isInRole)
                        {
                            authorized = true;
                            break;
                        }
                    }
                }

                if (!authorized)
                {
                    throw new ForbiddenAccessException();
                }
            }
        }

        return await next();
    }
}
