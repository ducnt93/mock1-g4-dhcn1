using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Data;
namespace DbMock1G4.BusinessLogic
{
    public static class ServerCache
    {
       // Xóa cache trong khi thực hiện thêm mới
        private static void Insert(string cacheName, object obj)
        {
            Insert(cacheName, obj, null, DateTime.MaxValue);
        }

       
        public static void Insert(string cacheName, object obj, string cacheKey)
        {
            Insert(cacheName, obj);
            var listName = Get(cacheKey) as List<string>;
            if (listName == null)
            {
                listName = new List<string> {cacheName};
            }
            else
            { 
                var isexist = false;
                foreach (var keyname in listName)
                {
                    if (keyname != cacheName) continue;
                    isexist = true;
                    break;
                }
                if (!isexist) listName.Add(cacheName);
            }
            Insert(cacheKey, listName, null, DateTime.MaxValue);
        }


        private static void Insert(string cacheName, object obj, CacheDependency dep, DateTime dt)
        {
            HttpRuntime.Cache.Insert(cacheName, obj, dep, dt, TimeSpan.Zero);
        }

       
        public static object Get(string cacheName)
        {
            return HttpRuntime.Cache.Get(cacheName);
        }

        
        public static void Remove(string cacheKey, bool all)
        {
            if (all)
            {
                List<string> listName = Get(cacheKey) as List<string>;
                if (listName != null)
                {
                    foreach (string name in listName)
                    {
                        Remove(name);
                        string fileCachedPath = StorePath + name + ".xml";
                        if (System.IO.File.Exists(fileCachedPath))
                            System.IO.File.Delete(StorePath);
                    }
                }
            }
            else
            {
                Remove(cacheKey);
            }
        }

     
        public static void Remove(string cacheName)
        {
            HttpRuntime.Cache.Remove(cacheName);
        }

        static readonly string StorePath = HttpContext.Current.Server.MapPath("~/App_Data/");

      
        public static void CacheDataSet2Xml(string cacheKey, DataSet ds)
        {
            string fileCachedPath = StorePath + cacheKey + ".xml";
            if (!System.IO.Directory.Exists(StorePath))
                System.IO.Directory.CreateDirectory(StorePath);
            ds.WriteXml(fileCachedPath);
            Insert(cacheKey, ds, new CacheDependency(fileCachedPath), DateTime.MaxValue);
        }
    }
}
