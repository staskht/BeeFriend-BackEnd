using BeeFriend.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Results
{
    public record Error(ErrorType Type, string id, string Description);

    public static class Errors
    {
        //Authentication Errors
        public static Error InvalidCredentials { get; } = new(
            ErrorType.Unauthorized, 
            "InvalidCredentials", 
            "Invalid email or password.");

        public static Error InvalidAccessToken { get; } = new(
            ErrorType.Unauthorized,
            "InvalidAccessToken",
            "Invalid access token.");

        public static Error InvalidRefreshToken { get; } = new(
            ErrorType.Unauthorized,
            "InvalidRefreshToken",
            "Invalid refresh token.");

        //Validation
        public static Error Validation(string id, string description) => 
            new(ErrorType.Validation, id, description);

        public static Error EmptyGuid(string parameterName) =>
            new(ErrorType.Validation, 
                "EmptyGuid", $"{parameterName} cannot be empty");

        // User

        public static Error UserNotFound { get; } = new(
            ErrorType.NotFound, 
            "UserNotFound", 
            "User could not be found");
         
    }
}
