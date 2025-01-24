using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Identity.API.Authorization
{
    public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
        {
            var dataNascimentoClain = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);
            if(dataNascimentoClain is null) return Task.CompletedTask;

            var dataNascimento = Convert.ToDateTime(dataNascimentoClain.Value);
            var idadeUsuario = DateTime.Today.Year - dataNascimento.Year;
            if (dataNascimento > DateTime.Today.AddYears(-idadeUsuario)) idadeUsuario--; //31/12/2000 > 01/01/2020-20 -> 20-1 = 19
            if (idadeUsuario >= requirement.Idade) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
