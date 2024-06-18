using Blog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.Users.GetAllUser;
public record GetAllUsersByPageResponse(
    ICollection<ShortUserViewModel> UserList,
    int TotalCount);
