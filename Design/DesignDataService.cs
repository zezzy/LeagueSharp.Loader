﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LeagueSharp.Loader.Model.Assembly;
using LeagueSharp.Loader.Model.Service;

namespace LeagueSharp.Loader.Design
{
    internal class DesignDataService : IDataService
    {
        public void GetAssemblyDatabase(Action<ObservableCollection<LeagueSharpAssembly>, Exception> callback)
        {
            callback(
                new ObservableCollection<LeagueSharpAssembly>
                {
                    new LeagueSharpAssembly
                    {
                        Name = "Support is too Easy",
                        Type = AssemblyType.Unknown,
                        Version = 0,
                        Author = "h3h3",
                        Location = "https://github.com/h3h3/LeagueSharp",
                        Versions =
                            new List<AssemblyVersion>
                            {
                                new AssemblyVersion {Id = 1, Color = "Green", Date = DateTime.Now, Message = "Message"}
                            }
                    }
                }, null);
        }
    }
}