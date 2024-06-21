using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Models.Requests;
public record GetEntityModelByPageRequest(
    int PageIndex = 1,
    int PageSize = 10);
