﻿using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateSaleProfile()
    {
        //CreateMap<CreateUserCommand, User>();
        //CreateMap<User, CreateUserResult>();
    }
}
