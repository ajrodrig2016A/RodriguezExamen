using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RodriguezExamen
{
    public partial class Registro : ContentPage
    {
        private const int costoCurso = 1800;
        private const int nroCuotas = 3;
        double totalPago = Double.NaN;

        public Registro(string usuario)
        {
            InitializeComponent();

            //Envío a los labels
            lblUsuario.Text = usuario;
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {

            try
            {
                if (!String.IsNullOrEmpty(txtMontoInicial.Text))
                {
                    double montoInicial = Convert.ToDouble(txtMontoInicial.Text);
                    double saldoPendiente = Math.Round((costoCurso - montoInicial), 2);
                    if (montoInicial > 0.00 && montoInicial <= Convert.ToDouble(costoCurso) && saldoPendiente > 0)
                    {
                        double pagoCtaMensualConRecargo = (saldoPendiente / 3) + (0.05 * Math.Round(Convert.ToDouble(costoCurso), 2));
                        txtPagoMensual.Text = Convert.ToString(pagoCtaMensualConRecargo);
                        totalPago = Math.Round((montoInicial + nroCuotas * pagoCtaMensualConRecargo), 2);
                    }
                    else if (montoInicial > 0.00 && montoInicial <= Convert.ToDouble(costoCurso) && saldoPendiente == 0)
                    {
                        totalPago = montoInicial;
                        DisplayAlert("Mensaje de alerta", "Se canceló el valor completo del curso.", "OK");
                    }
                    else
                    {
                        DisplayAlert("Mensaje de alerta", "No se permite monto Inicial mayor que 1800 o menor que 0", "OK");
                    }

                }
                else
                {
                    DisplayAlert("Mensaje de alerta", "No se permite monto Inicial mayor que 1800 o menor que 0", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
            }


        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (totalPago > 0)
            {
                string usuario = lblUsuario.Text;
                string nombre = txtNombre.Text;
                await Navigation.PushAsync(new Resumen(usuario, nombre, totalPago));
            }
            else
            {
                await DisplayAlert("Mensaje de alerta", "Para mostrar el resumen de inscripción, favor ingrese el nombre.", "OK");
            }

        }
    }
}
