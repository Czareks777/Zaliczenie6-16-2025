using System;
using System.Collections.Generic;

namespace FlyweightIconManager
{

    public class Icon
    {
        private readonly string _name;
        private readonly string _path;

        public string Name => _name;
        public string Path => _path;

        public Icon(string name, string path)
        {
            _name = name;
            _path = path;
            
        }

        public void Display(int size)
        {
            Console.WriteLine($"Wyświetlanie ikony: {Name}, rozmiar: {size}");
        }
    }


    public class IconFactory
    {
        private readonly Dictionary<string, Icon> _icons = new();

        public Icon GetIcon(string name, string path)
        {
            if (!_icons.TryGetValue(name, out var icon))
            {
                icon = new Icon(name, path);
                _icons[name] = icon;
            }
            return icon;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var factory = new IconFactory();

            var iconRequests = new List<(string name, string path, int size)>
            {
                ("icon1.png", "icons/icon1.png", 32),
                ("icon1.png", "icons/icon1.png", 32),
                ("icon2.png", "icons/icon2.png", 64),
                ("icon1.png", "icons/icon1.png", 64),
                ("icon2.png", "icons/icon2.png", 64),
            };


            foreach (var (name, path, size) in iconRequests)
            {
                var icon = factory.GetIcon(name, path);
                icon.Display(size);
            }
        }
    }
}
