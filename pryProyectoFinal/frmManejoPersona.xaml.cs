using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace pryProyectoFinal
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class frmManejoPersona 
    {
        clsPersona objPersona = new clsPersona();
        int idpersona = 0;
        public frmManejoPersona()
        {
            this.InitializeComponent();
            lsvPersonas.ItemsSource = objPersona.consultarPersona();
            cmbGrupoSanguineo.Items.Add("A+");
            cmbGrupoSanguineo.Items.Add("O+");
            cmbGrupoSanguineo.Items.Add("AB+");
            cmbGrupoSanguineo.Items.Add("B+");
            cmbGrupoSanguineo.Items.Add("A-");
            cmbGrupoSanguineo.Items.Add("O-");
            cmbGrupoSanguineo.Items.Add("AB-");
            cmbGrupoSanguineo.Items.Add("B-");

            cmbEstadoCivil.Items.Add("Casado");
            cmbEstadoCivil.Items.Add("Soltero");
            cmbNacionalidad.Items.Add("Ecuador");
            cmbNacionalidad.Items.Add("Colombianos");
        }

        string mensaje = "";
        private async void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string genero = "";
            if (chkbxMasculino.IsChecked==true)
            {
                genero = "Masculino";
            }else if(chkbxFemenino.IsChecked==true){
                genero = "Femenino";
            }
            try
            {
                if (objPersona.ingresarPersona(txtNombres.Text, txtApellidos.Text, genero, int.Parse(txtCedula.Text), 
                    cmbNacionalidad.SelectedItem.ToString(), txtDireccion.Text, dtpFechaNacimiento.Date.Date, cmbGrupoSanguineo.SelectedItem.ToString(),
                    cmbEstadoCivil.SelectedItem.ToString(),txtProfesion.Text))
                {
                    mensaje = "Ingreso Correcto";
                    MessageDialog showDialog = new MessageDialog(mensaje);
                    await showDialog.ShowAsync();
                }
                limpiarCampos();
            }
            catch (Exception ex)
            {
                mensaje = "Ingreso Incorrecto";
                MessageDialog showDialog = new MessageDialog(mensaje);
                await showDialog.ShowAsync();
            }
            lsvPersonas.ItemsSource = objPersona.consultarPersona();
        }

        private async void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            string genero = "";
            if (chkbxMasculino.IsChecked == true)
            {
                genero = "Masculino";
            }
            else if (chkbxFemenino.IsChecked == true)
            {
                genero = "Femenino";
            }
            if (objPersona.modificarPersona(idpersona, txtNombres.Text, txtApellidos.Text, genero, int.Parse(txtCedula.Text),
                    cmbNacionalidad.SelectedItem.ToString(), txtDireccion.Text, dtpFechaNacimiento.Date.Date, cmbGrupoSanguineo.SelectedItem.ToString(),
                    cmbEstadoCivil.SelectedItem.ToString(), txtProfesion.Text))
            {
                mensaje = "Moficación Correcta";
                MessageDialog showDialog = new MessageDialog(mensaje);
                await showDialog.ShowAsync();
            }
            lsvPersonas.ItemsSource = objPersona.consultarPersona();
            limpiarCampos();
        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (objPersona.eliminarPersona(idpersona))
            {
                mensaje = "Eliminación Correcta";
                MessageDialog showDialog = new MessageDialog(mensaje);
                await showDialog.ShowAsync();
            }
            lsvPersonas.ItemsSource = objPersona.consultarPersona();
        }

        private void BtnVisualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiarCampos();
        }
        public void limpiarCampos()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            chkbxMasculino.IsChecked = false;
            chkbxFemenino.IsChecked = false;
            txtCedula.Text = "";
            dtpFechaNacimiento.Date = DateTime.Now;
            //cmbNacionalidad.SelectedItem;
            txtDireccion.Text = "";
            txtProfesion.Text = "";
            //cmbGrupoSanguineo.SelectedItem=;
            //cmbEstadoCivil.SelectedItem=;
        }

        private void LsvPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clsPersona seleccionado = (clsPersona)lsvPersonas.SelectedItem;

            if (seleccionado != null)
            {
                txtNombres.Text = seleccionado.Nombres;
                txtApellidos.Text = seleccionado.Apellidos;
                txtCedula.Text = seleccionado.Cedula.ToString();
                if (seleccionado.Genero=="Masculino")
                {
                    chkbxMasculino.IsChecked = true;
                }else if (seleccionado.Genero=="Femenino")
                {
                    chkbxFemenino.IsChecked = true;
                }
                dtpFechaNacimiento.Date = seleccionado.FechaNacimiento.Date;
                cmbNacionalidad.SelectedItem = seleccionado.Nacionalidad;
                txtDireccion.Text = seleccionado.Direccion;
                txtProfesion.Text = seleccionado.Profesion;
                cmbGrupoSanguineo.SelectedItem = seleccionado.GrupoSanguineo;
                cmbEstadoCivil.SelectedItem = seleccionado.EstadoCivil;
                idpersona = seleccionado.IdPersona;

            }
        }

        private void cmbGrupoSanguineo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbEstadoCivil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbNacionalidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
