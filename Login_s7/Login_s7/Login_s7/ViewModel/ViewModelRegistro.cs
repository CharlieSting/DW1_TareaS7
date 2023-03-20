
using Login_s7.Model;
using Login_s7.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xamarin.Forms;

namespace Login_s7.ViewModel
{
    public class ViewModelRegistro : INotifyPropertyChanged
    {

        public ViewModelRegistro()
        {



            Registrar = new Command(async () =>
            {


                using (var httpClient = new HttpClient())
                {

                    Registro body1 = new Registro()
                    {
                        num_identidad = this.identidad,
                        nombre_cliente = this.nombre,
                        correo_cliente = this.correo,
                        direccion = this.direccion,
                        telefono = this.telefono,
                        id_departamento = this.id_dept,
                        pass = this.contrasena,
                        active = this.active = 1, 
                        id_rol = this.rol =1
                    };

                    var myContent = JsonConvert.SerializeObject(body1);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                    var respuesta = await httpClient.PostAsync(url, stringContent);

                    if (respuesta.IsSuccessStatusCode)
                    {

                        Resultado = "Felicidades, su usuario ha sido creado";
                        // await Application.Current.MainPage.Navigation.PushAsync(new ViewInicio());

                    }

                }

            });

        }






            string url = "https://desfrlopez.me/cmartinez/api/cliente/";
        

      
        string nombre;
        public string Nombre
        {

            get => nombre;
            set
            {

                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, args);

            }

        }

        string identidad;
        public string Identidad
        {

            get => identidad;
            set
            {

                identidad = value;
                var args = new PropertyChangedEventArgs(nameof(Identidad));
                PropertyChanged?.Invoke(this, args);

            }

        }

        string correo;
        public string Correo
        {

            get => correo;
            set
            {

                correo = value;
                var args = new PropertyChangedEventArgs(nameof(Correo));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string direccion;
        public string Direccion
        {

            get => direccion;
            set
            {

               direccion = value;
                var args = new PropertyChangedEventArgs(nameof(Direccion));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string telefono;
        public string Telefono
        {

            get => telefono;
            set
            {

                telefono = value;
                var args = new PropertyChangedEventArgs(nameof(Telefono));
                PropertyChanged?.Invoke(this, args);
            }
        }

        int id_dept;
        public int Id_dept
        {

            get => id_dept;
            set
            {

               id_dept = value;
                var args = new PropertyChangedEventArgs(nameof(Id_dept));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string contrasena;
        public string Contrasena
        {

            get => contrasena;
            set
            {

                contrasena = value;
                var args = new PropertyChangedEventArgs(nameof(Contrasena));
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

        int active;
        public int Active
        {

            get => active;
            set
            {

                active = value;
                var args = new PropertyChangedEventArgs(nameof(Active));
                PropertyChanged?.Invoke(this, args);

            }

        }

        int rol ;
        public int Rol
        {

            get => rol;
            set
            {

                rol = value;
                var args = new PropertyChangedEventArgs(nameof(Rol));
                PropertyChanged?.Invoke(this, args);

            }

        }
        public Command Registrar { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
