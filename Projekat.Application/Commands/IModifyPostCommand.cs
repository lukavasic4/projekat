﻿using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Application.DataTransfer;

namespace Projekat.Application.Commands
{
    public interface IModifyPostCommand : ICommandUpdate<PostDto,int>
    {
    }
}
