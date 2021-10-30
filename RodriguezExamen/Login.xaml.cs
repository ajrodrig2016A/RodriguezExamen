using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RodriguezExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //almacenar datos en variables
                string usuario = txtUsuario.Text;
                string clave = txtContrasena.Text;

                if (usuario == "estudiante2021" && clave == "uisrael2021")
                {
                    //Navegando a la ventana principal
                    await Navigation.PushAsync(new Registro(usuario));
                }
                else
                {
                    await DisplayAlert("Mensaje informativo", "Datos de ingreso son incorrectos", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje de expeción", ex.Message, "OK");
            }
        }
    }
}