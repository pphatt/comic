﻿using comic.Data;
using comic.Interfaces;
using comic.Models;
using comic.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace comic.Repository;

public class UserRepository : IUsersRepository
{
    private readonly ComicContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRepository(ComicContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;

        _userManager = userManager;

        _roleManager = roleManager;
    }

    public async Task<IEnumerable<ManageUsersViewModel>> GetAll()
    {
        var users = await _userManager.Users.ToListAsync();
        var userRolesViewModel = new List<ManageUsersViewModel>();

        foreach (var user in users)
        {
            userRolesViewModel.Add(new ManageUsersViewModel()
            {
                Id = user.Id,
                Email = user.Email!,
                UserName = user.UserName!,
                Roles = new List<string>(await _userManager.GetRolesAsync(user)),
            });
        }

        return userRolesViewModel;
    }
    
    public async Task<IEnumerable<IdentityRole>> GetAllRoles()
    {
        var role = await _roleManager.Roles.ToListAsync();

        return role;
    }

    public bool Add(User user)
    {
        _context.Add(user);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}