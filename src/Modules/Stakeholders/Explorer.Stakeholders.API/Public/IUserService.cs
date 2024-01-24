﻿using Explorer.Stakeholders.API.Dtos;
using FluentResults;
namespace Explorer.Stakeholders.API.Public
{
    public interface IUserService
    {
        Result<UserDto> Block(string username); // Change the return type here
        Result<List<UserDto>> GetAll();
    }
}
