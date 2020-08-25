using ERPOmarKamal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ERPOmarKamal
{
    /// <summary>
    /// Summary description for ItemsList
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ItemsList : System.Web.Services.WebService
    {
        private omarKamalEntities cx = new omarKamalEntities();


        [WebMethod]
        public List<المخزن> FetchItemList(string item)
        {
            
            var fetchitems = cx.المخزن.Select(x=>x)
            .Where(m => m.اسم_الصنف.ToLower().StartsWith(item.ToLower()));
            return fetchitems.ToList();
        }
    }
}
