using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JHipsterNet.Core.Pagination;
using JHipsterNet.Core.Pagination.Extensions;
using Gateway.Domain.Entities;
using Gateway.Security;
using Gateway.Domain.Services.Interfaces;
using Gateway.Dto;
using Gateway.Web.Extensions;
using Gateway.Web.Rest.Utilities;
using Gateway.Crosscutting.Constants;
using Gateway.Crosscutting.Exceptions;
using Gateway.Infrastructure.Web.Rest.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gateway.Controllers;


[Route("api/users")]
[ApiController]
public class PublicUsersController : ControllerBase
{
    private readonly ILogger<UsersController> _log;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public PublicUsersController(ILogger<UsersController> log, IUserService userService, IMapper mapper)
    {
        _log = log;
        _userService = userService;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllPublicUsers(IPageable pageable)
    {
        _log.LogDebug("REST request to get a page of Users");
        var page = await _userService.GetAllPublicUsers(pageable);
        var userDtos = page.Content.Select(user => _mapper.Map<UserDto>(user));
        var headers = page.GeneratePaginationHttpHeaders();
        return Ok(userDtos).WithHeaders(headers);
    }

}
