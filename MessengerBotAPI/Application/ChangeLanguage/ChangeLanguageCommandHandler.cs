using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;

namespace MessengerBotAPI.Application.ChangeLanguage
{
    public class ChangeLanguageCommandHandler : IRequestHandler<ChangeLanguageCommand, Result<object>>
    {
        public async Task<Result<object>> Handle(ChangeLanguageCommand request, CancellationToken cancellationToken)
        {
            return Result.Ok("language change failed");

        }
    }
}