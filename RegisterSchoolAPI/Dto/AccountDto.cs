﻿namespace RegisterSchoolAPI.Dto
{
    public class AccountDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PerfilId { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
