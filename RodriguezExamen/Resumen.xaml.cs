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
    public partial class Resumen : ContentPage
    {
        public Resumen(string usuario, string nombre, double totalPago)
        {
            InitializeComponent();
            //Asigno valores a los elementos
            lblUsuario.Text = usuario;
            txtNombre.Text = nombre;
            txtTotalPago.Text = Convert.ToString(totalPago);

        }
    }
}