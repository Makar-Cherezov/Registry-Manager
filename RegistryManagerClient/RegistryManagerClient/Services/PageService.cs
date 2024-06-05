using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace RegistryManagerClient.Services
{
    public class PageService
    {
        private static readonly Lazy<PageService> _instance = new Lazy<PageService>(() => new PageService());
        private readonly Dictionary<Type, Page> _pages;

        private PageService()
        {
            _pages = new Dictionary<Type, Page>();
        }

        public static PageService Instance => _instance.Value;

        public T GetPage<T>() where T : Page, new()
        {
            var type = typeof(T);
            if (!_pages.ContainsKey(type))
            {
                _pages[type] = new T();
            }
            return (T)_pages[type];
        }
    }

}
