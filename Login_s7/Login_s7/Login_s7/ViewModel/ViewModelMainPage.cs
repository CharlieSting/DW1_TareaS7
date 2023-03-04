using Login_s7.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;
using Login_s7.View;

namespace Login_s7.ViewModel
{
    public class ViewModelMainPage : INotifyPropertyChanged
    {

        public ViewModelMainPage()
        {
            inicioSesion = new Command(async () =>
            {
                HttpClient cliente = new HttpClient();
                var respuesta = await cliente.GetAsync(url + this.correo_cliente + "/"+this.pass);

                if (respuesta.IsSuccessStatusCode)
                {

                    var contenido = await respuesta.Content.ReadAsStringAsync();



                    var inicioSesion = System.Text.Json.JsonSerializer.Deserialize<List<login>>(contenido);


                    if (inicioSesion[0].is_valid == 1)
                    {

                        await Application.Current.MainPage.Navigation.PushAsync(new ViewInicio());

                    }
                    else
                    {

                        Resultado = "Usuario o contraseña invalidos";
                    }

                }

            });
        }

        INavigation navigation;

        string url = "https://desfrlopez.me/cmartinez/api/login/";

        string correo_cliente;
        public string Correo_cliente
        {
            get => correo_cliente;
            set
            {
                correo_cliente = value;
                var args = new PropertyChangedEventArgs(nameof(Correo_cliente));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string pass;
        public string Pass
        {
            get => pass;
            set
            {
                pass = value;
                var args = new PropertyChangedEventArgs(nameof(Pass));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string resultado;
        public string Resultado
        {
            get => resultado;
            set
            {
                resultado = value;
                var args = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, args);

            }
        }


        public Command inicioSesion { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
