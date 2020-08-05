using SURSYSTEM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SURSYSTEM.Infraestructura
{
    public class InstanseLocator
    {
        public MainViewModel Main { get; set; }

        public InstanseLocator()
        {
            Main = new MainViewModel();
        }
    }
}
