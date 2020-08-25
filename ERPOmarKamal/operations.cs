using ERPOmarKamal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ERPOmarKamal
{
    public class operations
    {
       
        private omarKamalEntities cx = new omarKamalEntities();
        [WebMethod]
        public  List<المخزن> binddata(string name)
        {
          var data=  cx.المخزن.Select(x=>x).Where(m => m.اسم_الصنف.ToLower().StartsWith(name.ToLower()));
            return data.ToList();
        } 


    }
}