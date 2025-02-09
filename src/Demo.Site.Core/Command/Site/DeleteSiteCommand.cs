﻿using System;
using System.Threading.Tasks;
using Demo.Business.BusinessModule;
using Demo.Common.Command;
using Demo.Data;
using Demo.Data.Repository;
using Demo.User;
using Demo.User.Identity;

namespace Demo.Business.Command.Site
{
    public class DeleteSiteCommand : Command<UserInput<string>, CommandResult>
    {
        private readonly BusinessModuleFactory _businessModuleFactory;
        private readonly IDataFactory _dataFactory;
        private readonly UserService _userService;
        private readonly ICacheRepository _cacheRepository;

        public DeleteSiteCommand(IDataFactory dataFactory, UserService userService, BusinessModuleFactory businessModuleFactory, ICacheRepository cacheRepository)
        {
            _dataFactory = dataFactory;
            _userService = userService;
            _businessModuleFactory = businessModuleFactory;
            _cacheRepository = cacheRepository;
        }

        protected override void Action()
        {
            throw new NotImplementedException();
        }

        protected override async Task ActionAsync()
        {
            await UserSecurity.CheckIsSuperAdministratorAsync(_userService, Input.UserId);

            var siteRepository = _dataFactory.ItemRepository;
            var siteDataModel = await siteRepository.GetItemAsync(null, Input.Data);

            var module = _businessModuleFactory.GetModuleCreate(siteDataModel.Module);
            if (module != null)
            {
                await module.DeleteAsync(_dataFactory, _cacheRepository, siteDataModel);
            }

            //await Data.DeleteAsync(siteDataModel);
            await _dataFactory.SaveChangeAsync();

            await _userService.RemoveRoleAsync(Input.Data);
            //await _seoService.ClearAsync(Input.Data);
           // await _cacheProvider.RemoveCacheAsync(Input.Data);
        }
    }
}