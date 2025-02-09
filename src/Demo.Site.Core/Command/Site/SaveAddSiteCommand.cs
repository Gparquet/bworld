﻿using System;
using System.Dynamic;
using System.Threading.Tasks;
using Demo.Business.BusinessModule;
using Demo.Business.Command.Free;
using Demo.Common.Command;
using Demo.Data;
using Demo.User;
using Demo.User.Identity;

namespace Demo.Business.Command.Site
{
    /// <summary>
    ///     Command d'administration de la page de créatiopn des site
    /// </summary>
    public class SaveAddSiteCommand : Command<UserInput<SaveAddSiteInput>, CommandResult<dynamic>>
    {
        private readonly IDataFactory _dataFactory;
        private readonly UserService _userService;
        private readonly CacheProvider _cacheProvider;
        private readonly ModuleManager _moduleManager;

        public SaveAddSiteCommand(IDataFactory dataFactory, UserService userService, CacheProvider cacheProvider, ModuleManager moduleManager)
        {
            _dataFactory = dataFactory;
            _userService = userService;
            _cacheProvider = cacheProvider;
            _moduleManager = moduleManager;
        }

        protected override void Action()
        {
            throw new NotImplementedException();
        }

        protected override async Task ActionAsync()
        {
            var siteId = Input.Data.Site.SiteId;
           
            await UserSecurity.CheckAdministratorAsync(_userService, Input.UserId, siteId);
            var itemDataModel =
               await _dataFactory.ItemRepository.GetItemAsync(siteId, Input.Data.ModuleId, false, true);
            var addSiteBusinessModel = (AddSiteBusinessModel) itemDataModel.Data;

            addSiteBusinessModel.Templates = Input.Data.Templates;
            addSiteBusinessModel.UrlConditionsGeneralesUtilisations = Input.Data.UrlConditionsGeneralesUtilisations;

            var elements =
                await SaveFreeCommand.GetElementsAsync(_dataFactory, itemDataModel, Input.Data.Elements);
            // On enregistre l'element
            addSiteBusinessModel.Elements = elements;
            
            await _dataFactory.SaveChangeAsync();

            await _cacheProvider.UpdateCacheAsync(siteId);

            Result.Data = new ExpandoObject();
            Result.Data.Master = await _moduleManager.GetMasterAsync(Input.Data.Site);

        }
    }
}