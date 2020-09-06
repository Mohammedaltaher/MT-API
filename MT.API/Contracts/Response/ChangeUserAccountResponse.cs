using System.Collections.Generic;

namespace  AggriPortal.API.Contracts.Response
{
    public class ChangePasswordResponse : BaseResponse
    {
        public ChangePasswordResponse(bool isSuccess, int statusCode,string message)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            ResponseMessage = message;
        }
    }

    public class PasswordResetIssueResponse : BaseResponse
    {
        public PasswordResetIssueResponse(bool isSuccess, int statusCode, string message)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            ResponseMessage = message;
        }
    }

    public class PasswordResetResponse : BaseResponse
    {
        public PasswordResetResponse(bool isSuccess, int statusCode, string message)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            ResponseMessage = message;
        }

        public PasswordResetResponse(bool isSuccess, int statusCode, string message,List<ValidationError> errors)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            ResponseMessage = message;
            ValidationErrors = errors;
        }
    }

    public class ChangeUserNameResponse : BaseResponse
    {
        public ChangeUserNameResponse(bool isSuccess, int statusCode, string message)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            ResponseMessage = message;
        }
    }

    public class ChangeDefaultLanguageResponse : BaseResponse
    {
        public ChangeDefaultLanguageResponse(bool isSuccess, int statusCode, string message)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            ResponseMessage = message;
        }
    }

    public class ChangePhoneNumberResponse : BaseResponse
    {
        public ChangePhoneNumberResponse(bool isSuccess, int statusCode, string message)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            ResponseMessage = message;
        }
    }

    public class PasswordChangedByAdminResponseDto : BaseResponse
    {
        public PasswordChangedByAdminResponseDto(bool isSuccess, int statusCode, string message)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            ResponseMessage = message;
        }
    }
    public class ChangeEmailResponseDto : BaseResponse
    {
        public ChangeEmailResponseDto(bool isSuccess, int statusCode, string message)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            ResponseMessage = message;
        }
    }
    public class UserActivationResponseDto : BaseResponse
    {
        public UserActivationResponseDto(bool isSuccess, int statusCode, string message)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            ResponseMessage = message;
        }
    }
}
