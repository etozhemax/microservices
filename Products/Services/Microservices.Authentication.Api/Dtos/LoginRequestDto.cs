﻿namespace Microservices.Authentication.Api.Dtos
{
    public class LoginRequestDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
