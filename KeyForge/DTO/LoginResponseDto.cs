﻿namespace KeyForge.DTO
{
    public class LoginResponseDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
