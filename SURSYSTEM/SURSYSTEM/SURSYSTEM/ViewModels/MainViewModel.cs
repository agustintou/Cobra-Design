using System;
using System.Collections.Generic;
using System.Text;

namespace SURSYSTEM.ViewModels
{
    public class MainViewModel
    {
        public CalendarioViewModel Calendario { get; set; }
        public PersonasViewModel Personas { get; set; }

        public MainViewModel()
        {
            Personas = new PersonasViewModel();
        }
    }
}
