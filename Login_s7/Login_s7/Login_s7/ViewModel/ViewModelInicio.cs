using Login_s7.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Login_s7.ViewModel
{
    public class ViewModelInicio : INotifyPropertyChanged
    {


        public ViewModelInicio()
        {
            getPersonas();

        }


        private async void getPersonas()
        {

            ListPersonas = new ObservableCollection<cliente>();

            HttpClient httpClient = new HttpClient();

            var respuesta = await httpClient.GetAsync(url);

            if (respuesta.IsSuccessStatusCode)
            {

                var contenido = await respuesta.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var listado = System.Text.Json.JsonSerializer.Deserialize<List<cliente>>(contenido, opciones);


                foreach (var item in listado)
                {

                    ListPersonas.Add(item);


                }

            }
        }


        string url = "https://desfrlopez.me/cmartinez/api/cliente/";

        ObservableCollection<cliente> listPersonas = new ObservableCollection<cliente>();

        public ObservableCollection<cliente> ListPersonas
        {
            get => listPersonas;
            set
            {

                listPersonas = value;
                var args = new PropertyChangedEventArgs(nameof(ListPersonas));
                PropertyChanged?.Invoke(this, args);

            }


        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
