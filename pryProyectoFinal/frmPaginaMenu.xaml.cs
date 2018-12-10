using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class frmPaginaMenu : Page
    {
        public frmPaginaMenu()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(frmManejoPersona));
            NavigateToMainPage.IsChecked = true;
        }

        private void Hamburguer_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void GoBack_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Hamburguer_Click(object sender, RoutedEventArgs e)
        {
            if (Split.IsPaneOpen)
            {
                Split.IsPaneOpen = false;
            }
            else
            {
                Split.IsPaneOpen = true;
            }
            Hamburguer.IsChecked = false;
        }


        private void NavigateToMainPage_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmManejoPersona));
            NavigateToMainPage.IsChecked = true;
        }

        private void NavigateToPageOne_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmManejoSalario));
            NavigateToPageOne.IsChecked = true;
        }

        private void NavigateToPageTwo_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmManejoEspecialidad));
            NavigateToPageTwo.IsChecked = true;
        }

        private void NavigateToPageThree_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmManejoHorario));
            NavigateToPageThree.IsChecked = true;
        }

        private void NavigateToPageFour_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmManejoPermiso));
            NavigateToPageFour.IsChecked = true;
        }

        private void NavigateToPageFive_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmManejoVacaciones));
            NavigateToPageFive.IsChecked = true;
        }

        private void NavigateToPageSix_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmManejoMultas));
            NavigateToPageSix.IsChecked = true;
        }

        private void NavigateToPageSeven_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmManejoIngresoEmpleado));
            NavigateToPageSeven.IsChecked = true;
        }

        private void NavigateToPageEight_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmManejoAsistencia));
            NavigateToPageEight.IsChecked = true;
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if (ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
            }

            GoBack.IsChecked = false;
        }
    }
}
