﻿namespace Welsh.Framebot.Data.Models;

public class User
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string PasswordHash { get; set; }

    public List<Bot> Bots { get; set; } = [];
}