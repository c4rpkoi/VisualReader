﻿using MediatR;
using Microsoft.AspNetCore.Http;

namespace VisualReader
{
    public class UpdateProfileRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public IFormFile? AvatarFile { get; set; }
    }
}