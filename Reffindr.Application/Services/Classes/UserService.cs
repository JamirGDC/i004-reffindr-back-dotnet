﻿using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Response.User;

namespace Reffindr.Application.Services.Classes;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    private readonly IImageService _imageService;

    public UserService
        (
            IUnitOfWork unitOfWork,
            IUserContext userContext,
            IUsersRepository usersRepository,
            IImageService imageService
        )
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _imageService = imageService;
    }

    public async Task<UserUpdateResponseDto> UpdateUserAsync(UserUpdateRequestDto userRequestDto, CancellationToken cancellationToken)
    {
        int userId = _userContext.GetUserId();

        User user = await _unitOfWork.UsersRepository.GetById(userId);

        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null.");
        }

        string imageUrl = await _imageService.UploadImagesAsync(userRequestDto.ProfileImage!);


        user.Name = userRequestDto.Name ?? user.Name;
        user.LastName = userRequestDto.LastName ?? user.LastName;
        user.Dni = userRequestDto.Dni ?? user.Dni;
        user.Phone = userRequestDto.Phone ?? user.Phone;
        user.Address = userRequestDto.Address ?? user.Address;
        user.BirthDate = userRequestDto.BirthDate ?? user.BirthDate;
        user.UpdatedAt = DateTime.UtcNow;
        if (user.Image != null)
        {
            user.Image.ImageUrl = imageUrl;
            user.Image.UpdatedAt = DateTime.UtcNow;
        }
        else
        {
            user.Image = new Image
            {
                ImageUrl = imageUrl,
                CreatedAt = DateTime.UtcNow
            };
        }

        user.IsProfileComplete = !string.IsNullOrWhiteSpace(user.Name) &&
                             !string.IsNullOrWhiteSpace(user.LastName) &&
                             !string.IsNullOrWhiteSpace(user.Dni) &&
                             !string.IsNullOrWhiteSpace(user.Phone) &&
                             !string.IsNullOrWhiteSpace(user.Address) &&
                             user.BirthDate.HasValue;

        await _unitOfWork.Complete(cancellationToken);

        UserUpdateResponseDto userUpdateResponseDto = user.ToResponse();

        return userUpdateResponseDto;

    }

    public async Task<UserCredentialsResponseDto> GetUserCredentialsAsync()
    {
        int userId = _userContext.GetUserId();
        User userCredentials = await _unitOfWork.UsersRepository.GetById(userId);

        UserCredentialsResponseDto userCredentialsResponse = userCredentials.ToUserCredentialsResponse();

        return userCredentialsResponse;
    }


}
