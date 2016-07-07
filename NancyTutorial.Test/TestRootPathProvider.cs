﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using System.IO;

namespace NancyTutorial.Test
{
    public class TestRootPathProvider:IRootPathProvider
    {
        private static string _cachedRootPath;

        public string GetRootPath()
        {
            if (!string.IsNullOrEmpty(_cachedRootPath))
                return _cachedRootPath;

            var currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);

            bool rootPathFound = false;
            while(!rootPathFound)
            {
                var directoriesContainingViewFolder = currentDirectory.GetDirectories("Views", SearchOption.AllDirectories);
                if(directoriesContainingViewFolder.Any())
                {
                    _cachedRootPath = directoriesContainingViewFolder.First().FullName;
                    rootPathFound = true;
                }

                currentDirectory = currentDirectory.Parent;
            }
            return _cachedRootPath;
        }
    }
}
