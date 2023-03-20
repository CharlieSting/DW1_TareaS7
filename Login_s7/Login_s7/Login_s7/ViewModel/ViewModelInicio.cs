using Login_s7.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;

namespace Login_s7.ViewModel
{
    public class ViewModelInicio : INotifyPropertyChanged
    {

        public ViewModelInicio()
        {


            EnviarTicket = new Command(async () =>
            {


                using (var httpClient = new HttpClient())
                {

                    cliente ticket = new cliente()
                    {
                        fecha = this.fecha,
                        id_estado = this.estado = 1,
                        id_cliente = this.client,
                        id_prioridad = this.prioridad,
                        asunto = this.asunto,
                        descripcion_ticket = this.descripcion,
                       
                    };

                    var myContent = JsonConvert.SerializeObject(ticket);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PostAsync(url, stringContent);

                    if (respuesta.IsSuccessStatusCode)
                    {

                        Mensaje = "Su ticket ha sido enviado";
                        // await Application.Current.MainPage.Navigation.PushAsync(new ViewInicio());

                    }

                }

            });

        }


        string url = "https://desfrlopez.me/cmartinez/api/ticket/";

        string fecha;
        public string Fecha
        {

            get => fecha;
            set
            {

                fecha = value;
                var args = new PropertyChangedEventArgs(nameof(Fecha));
                PropertyChanged?.Invoke(this, args);

            }

        }

       int estado;
        public int Estado
        {

            get => estado;
            set
            {

                estado = value;
                var args = new PropertyChangedEventArgs(nameof(Estado));
                PropertyChanged?.Invoke(this, args);

            }

        }

        int client;
        public int Cliente
        {

            get => client;
            set
            {

                client = value;
                var args = new PropertyChangedEventArgs(nameof(Cliente));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int prioridad;
        public int Prioridad
        {

            get => prioridad;
            set
            {

                prioridad = value;
                var args = new PropertyChangedEventArgs(nameof(Prioridad));
                PropertyChanged?.Invoke(this, args);

            }

        }

        string asunto;
        public string Asunto
        {

            get => asunto;
            set
            {

                asunto = value;
                var args = new PropertyChangedEventArgs(nameof(Asunto));
                PropertyChanged?.Invoke(this, args);

            }

        }

        string descripcion;
        public string Descripcion
        {

            get => descripcion;
            set
            {

                descripcion = value;
                var args = new PropertyChangedEventArgs(nameof(Descripcion));
                PropertyChanged?.Invoke(this, args);

            }

        }

        string mensaje;
        public string Mensaje
        {

            get => mensaje;
            set
            {

                mensaje = value;
                var args = new PropertyChangedEventArgs(nameof(Mensaje));
                PropertyChanged?.Invoke(this, args);

            }

        }


        public Command EnviarTicket { get; }

        public Command VerTicket { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
