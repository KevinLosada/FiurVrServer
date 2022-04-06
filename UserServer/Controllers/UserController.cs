﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;
using UserServer.Services;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("{username}")]
    public User Post([FromRoute]string username)
    {
        _userService.CreateUser(username);

        return _userService.GetUser(username);
    }
    
    [HttpGet]
    public List<User> Get()
    {
        Console.WriteLine("Outputting users");
        return _userService.GetAll();
    }

    [HttpGet("{username}")]
    public User Get([FromRoute] string username)
    { 
        return _userService.GetUser(username);
    }
    
    //update inventory
    [HttpPut("{username}/inventory")]
    public User Put([FromRoute] string username, [FromQuery] int item, [FromQuery] int quantity)
    {
        return _userService.UpdateInventory(username, item, quantity);
    }

    [HttpDelete("{username}")]
    public void Delete([FromRoute] string username)
    {
        _userService.DeleteUser(username);
    }
    
    //update userprefs
    [HttpPut("{username}/preferences")]
    public User Put([FromRoute] string username, [FromQuery] int head, [FromQuery] int skin, [FromQuery] int face,
        [FromQuery] int hair, [FromQuery] int color)
    {
        return _userService.UpdatePreferences(username, head, skin, face, hair, color);
    }
}
