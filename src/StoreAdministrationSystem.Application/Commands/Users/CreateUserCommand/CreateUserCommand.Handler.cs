using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.DataAccess.Repositories.Users;
using StoreAdministrationSystem.Domain.Users;

namespace StoreAdministrationSystem.Application.Commands.Users;

public sealed partial class CreateUserCommand
{
    public sealed class Handler : ICommandHandler<
        CreateUserCommand,
        Results.SuccessResult,
        Results.FailResult>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByLoginAsync(request.Login, cancellationToken);

            if (user is not null)
                return AlreadyExist();

            var newUser = new User(request.Email, request.Login, request.Password, request.IsAdmin);

            await _userRepository.SaveAsync(newUser, cancellationToken);

            return Success();
        }
    }
}
