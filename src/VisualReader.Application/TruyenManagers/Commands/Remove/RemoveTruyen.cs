﻿using MediatR;

namespace VisualReader
{
    public class RemoveTruyen : IRequest<bool>//cái bool để trong Irequest là kiểu trả về nhá
    {
        public Guid Id { get; set; }

        public RemoveTruyen(Guid id) => Id = id;
    }
}