﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Projekat.Application;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;
using Projekat.Domain;
using Projekat.EfDataAccess;
using Projekat.Implementation.Validation;

namespace Projekat.Implementation.Commands
{
    public class EfCreatePostCommand : ICreatePostCommand
    {
        private readonly ProjekatContext _context;
        private readonly CreatePostValidation _validator;
        public EfCreatePostCommand(ProjekatContext context, CreatePostValidation validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 4;

        public string Name => "Create post using Ef";

       public void Execute(PostDto request)
        {
            _validator.ValidateAndThrow(request);
            var post = new Post
            {
                Title = request.Title,
                Text = request.Text,
                IdUser = request.IdUser,
                IdPicture = request.IdPicture
            };
            _context.Posts.Add(post);
            _context.SaveChanges();
            foreach (var c in request.Category)
            {
                var categories = new CategoryPost
                {
                    IdPost = post.Id,
                    IdCategory = c.Id

                };
                _context.CategoryPost.Add(categories);
                _context.SaveChanges();
            }
        }
    }
}
