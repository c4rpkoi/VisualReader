﻿using MediatR;
using VisualReader.Application.Services.Abstractions;

namespace VisualReader.Application.Users.Commands.Handlers
{
    public class VerifyRequestHandler : IRequestHandler<VerifyRequest, bool>
    {
        private readonly IUserService _service;

        public VerifyRequestHandler(IUserService service)
        {
            _service = service;
        }

        public Task<bool> Handle(VerifyRequest request, CancellationToken cancellationToken)
        {
            return _service.VerifyAccountAsync(request, cancellationToken);
        }
    }
}