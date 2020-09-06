namespace  AggriPortal.API.Resources
{
    public  class VerifyResetPasswordRequestDto
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string NewPassword { get; set; }

    }
}
