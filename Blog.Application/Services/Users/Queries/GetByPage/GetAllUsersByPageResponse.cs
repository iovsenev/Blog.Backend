﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Models.ViewModels;

namespace Blog.Application.Services.Users.Queries.GetByPage;
public record GetAllUsersByPageResponse(
    ICollection<ShortUserViewModel> UserList,
    int TotalCount);
