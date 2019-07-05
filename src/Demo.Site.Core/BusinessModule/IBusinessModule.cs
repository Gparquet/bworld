using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Business.BusinessModule.Models;
using Demo.Routing.Implementation;

namespace Demo.Business.BusinessModule
{
    public interface IBusinessModule
    {
        /// <summary>
        ///     Menu(s) li� au module
        /// </summary>
        /// <param name="geMenuItemInput"></param>
        /// <returns></returns>
        Task GetInfoAsync(GeMenuItemInput geMenuItemInput);

        /// <summary>
        ///     R�cup�re les Metadada du module root (main page)
        /// </summary>
        /// <param name="getRootMetaDataInput"></param>
        /// <returns></returns>
        IDictionary<string, string> GetRootMetadata(GetRootMetaDataInput getRootMetaDataInput);

        /// <summary>
        ///     Liste des route associ� au module
        /// </summary>
        /// <param name="domainDatas"></param>
        /// <returns></returns>
        IEnumerable<Route> GetRoutes(IDictionary<string, string> domainDatas);
    }
}