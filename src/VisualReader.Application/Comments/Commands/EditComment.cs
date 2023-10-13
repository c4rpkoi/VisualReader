﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Comments.Commands.Models;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.Comments.Commands
{
    public class EditComment:IRequest<CommentDto>
    {
        public Guid Id { get; set; }
        //public Guid? PostId { get; set; }
        //public Guid? ChapterId { get; set; }
        //public Guid? BookId { get; set; }
        //public Guid? UserId { get; set; }
        //public DateTime CreatedUtc { get; set; }
        //public DateTime UpdatedUtc { get; set; }
        public string Content { get; set; }
        //public User? User { get; set; }
        //public Chapter? Chapter { get; set; }
        //public Book? Book { get; set; }
        //public Post? Posts { get; set; }
        private static Func<EditComment, Comment> Converter = Projection.Compile();

        public static Expression<Func<EditComment, Comment>> Projection
        {
            get
            {
                return entity => new Comment
                {
                    Id = entity.Id,
                    //PostId = entity.PostId,
                    //ChapterId = entity.ChapterId,
                    //BookId = entity.BookId,
                    //UserId = entity.UserId,
                    //CreatedUtc = entity.CreatedUtc,
                    //UpdatedUtc = entity.UpdatedUtc,
                    Content = entity.Content,
                    //User = entity.User,
                    //Posts = entity.Posts,
                    //Chapter = entity.Chapter,
                    //Book = entity.Book
                };
            }
        }

        public static Comment Create(EditComment model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}