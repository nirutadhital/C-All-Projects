﻿namespace jwtDb.Models
{
    public class UserDto
    {
        public required int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
