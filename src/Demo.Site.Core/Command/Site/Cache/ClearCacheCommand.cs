﻿using System;
using System.Threading.Tasks;
using Demo.Common.Command;
using Demo.Data;
using Demo.User;
using Demo.User.Identity;

namespace Demo.Business.Command.Site.Cache
{
    public class ClearCacheCommand : Command<UserInput<string>, CommandResult>
    {
        private readonly UserService _userService;
        private readonly CacheProvider _cacheProvider;

        public ClearCacheCommand(UserService userService, CacheProvider cacheProvider)
        {
            _userService = userService;
            _cacheProvider = cacheProvider;
        }

        protected override async Task ActionAsync()
        {
          //  await UserSecurity.CheckIsSuperAdministratorAsync(_userService, Input.UserId);

            await _cacheProvider.InitializeCacheAsync();
        }

        protected override void Action()
        {
            throw new NotImplementedException();
        }
    }
}
