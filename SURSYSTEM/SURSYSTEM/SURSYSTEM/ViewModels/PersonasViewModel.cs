using GalaSoft.MvvmLight.Command;
using Rg.Plugins.Popup.Extensions;
using SURSYSTEM.Models;
using SURSYSTEM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SURSYSTEM.ViewModels
{
    public class PersonasViewModel
    {
        public ObservableCollection<PersonaModel> Personas { get; set; }

        public ObservableCollection<PersonaModel> personas;

        public PersonasViewModel()
        {
            Personas = new ObservableCollection<PersonaModel>();

            CargarListaPersona();
        }

        private void CargarListaPersona()
        {
            Personas.Add(new PersonaModel { Apellido = "Navarro", Nombre = "Mariano", Cargo = "Maestro 1" });
            Personas.Add(new PersonaModel { Apellido = "Navarro", Nombre = "Augusto", Cargo = "Maestro 2" });
            Personas.Add(new PersonaModel { Apellido = "Navarro", Nombre = "Virginia", Cargo = "Maestro 3" });
            Personas.Add(new PersonaModel { Apellido = "Navarro", Nombre = "Marcelo", Cargo = "Analista" });
        }

        public ICommand AgregarPersonaCommand
        {
            get
            {
                return new RelayCommand(AgregarPersona);
            }
        }

        private async void AgregarPersona()
        {
            await Application.Current.MainPage.Navigation.PushPopupAsync(new PersonaAddPage());
        }
    }
}
