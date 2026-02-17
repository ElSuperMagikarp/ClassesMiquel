using StoreProject.Infraestructure.Common;
using StoreProject.Infraestructure.DTO;
using StoreProject.Infraestructure.Services;
using StoreProject.Infraestructure.Persistance.Repository;

namespace StoreProject.Validators;

public static class UserADOValidator
{
    private const string UsernameDuplicatedMessage = "Aquest nom d'usuari ja existeix";
    private const string UsernameDuplicatedCode = "USERNAME_DUPLICAT";

    private const string EmailDuplicatedMessage = "Aquest correu ja està registrat";
    private const string EmailDuplicatedCode = "EMAIL_DUPLICAT";

    public static Result Validate(UserRequest user, DatabaseConnection dbConn)
    {
        var result = ValidateUsername(user, dbConn);
        if (!result.IsOk) return result;

        result = ValidateEmail(user, dbConn);
        if (!result.IsOk) return result;

        return Result.Ok();
    }

    private static Result ValidateUsername(UserRequest user, DatabaseConnection dbConn)
    {
        if (UserADO.UsernameExists(dbConn, user.Username))
            return Result.Failure(UsernameDuplicatedMessage, UsernameDuplicatedCode);

        return Result.Ok();
    }

    private static Result ValidateEmail(UserRequest user, DatabaseConnection dbConn)
    {
        if (UserADO.EmailExists(dbConn, user.Email))
            return Result.Failure(EmailDuplicatedMessage, EmailDuplicatedCode);

        return Result.Ok();
    }
}
