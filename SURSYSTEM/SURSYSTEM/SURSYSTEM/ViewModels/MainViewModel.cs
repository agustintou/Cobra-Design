using System;
using System.Collections.Generic;
using System.Text;

namespace SURSYSTEM.ViewModels
{
    public class MainViewModel
    {
        public CalendarioViewModel Calendario { get; set; }

        public MainViewModel()
        {
            Calendario = new CalendarioViewModel();
        }
    }
}
