﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;
using Projekat.Domain;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Commands
{
    public class EfCreatePictureCommand : ICreatePictureCommand
    {
        private readonly ProjekatContext _context;
        public EfCreatePictureCommand(ProjekatContext context)
        {
            _context = context;
        }
        public int Id => 13;

        public string Name => "Create picture";

        public void Execute(PictureDto request)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);
            var newFileName = guid + extension;
            var path = Path.Combine("wwwroot", "images", newFileName);
            var alt = Path.GetFileName(request.Image.Name);
            using (var fileStrem = new FileStream(path, FileMode.Create))
            {
                request.Image.CopyTo(fileStrem);
            }
            var picture = new Picture
            {
                Src = newFileName,
                Alt = alt
            };
            _context.Pictures.Add(picture);
            _context.SaveChanges();
        }
    }
}
