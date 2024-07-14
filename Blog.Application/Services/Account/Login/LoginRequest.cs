using Blog.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.Account.Login;
public record LoginRequest (string Email, string Password) : ICommand;