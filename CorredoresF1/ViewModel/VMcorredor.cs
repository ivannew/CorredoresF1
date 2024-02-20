using CorredoresF1.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net;

namespace CorredoresF1.ViewModel
{
    internal class VMcorredor:BaseViewModel
    {
        #region VARIABLES
        string _Id;
        string _Nombre;
        string _Numero;
        string _Equipo;
  
        #endregion
        #region CONSTRUCTOR
        public VMcorredor(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS
        public string Id
        {
            get { return _Id; }
            set { SetValue(ref _Id, value); }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { SetValue(ref _Nombre, value); }
        }
        public string Numero
        {
            get { return _Numero; }
            set { SetValue(ref _Numero, value); }
        }
        public string Equipo
        {
            get { return _Equipo; }
            set { SetValue(ref _Equipo, value); }
        }
    



        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public async Task Insertar()
        {
            Mcorredor mcorredor = new Mcorredor
            {
            
                Name = _Nombre,
                Number = _Numero,
                Team = _Equipo,
            };
            Uri RequestUri= new Uri("https://http://corredoresfor11.somee.com/api/drivers");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(mcorredor);
            var contentJson = new StringContent(json, Encoding.UTF8, "aplication/json"); 
            var response = await client.PostAsync(RequestUri, contentJson);

            if(response.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("Mensaje", "Registrado", "Ok");

            }
            else
            {
                await DisplayAlert("Mensaje", "No se registro", "Ok");
            }
        }
        public void procesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand InsertarCorredor => new Command(async () => await Insertar());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        
        #endregion
    }
}
