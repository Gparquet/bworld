﻿using System;
using System.Threading.Tasks;
using Demo.Common.Command;
using Demo.Data;
using Demo.User;
using Demo.User.Identity;

namespace Demo.Business.Command.Social
{
    public class GetSocialCommand : Command<GetModuleInput, CommandResult<GetSocialResult>>
    {
        private readonly IDataFactory _dataFactory;

        public GetSocialCommand(IDataFactory dataFactory)
        {
            _dataFactory = dataFactory;
        }

        protected override void Action()
        {
            throw new NotImplementedException();
        }

        protected override async Task ActionAsync()
        {
            var itemDataModel = await _dataFactory.ItemRepository.GetItemAsync(Input.SiteId, Input.ModuleId);

            if (itemDataModel == null)
            {
                Result.ValidationResult.AddError("NO_DATA_FOUND");
                return;
            }

            var moduleFree = (SocialBusinessModel) itemDataModel.Data;
            Result.Data = new GetSocialResult() {Data = moduleFree};
        }
    }
}