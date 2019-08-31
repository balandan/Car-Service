
using Proiect3WPF.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proiect3WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceReference1.Service1Client service;
        int ClientID;


        public MainWindow()
        {
            InitializeComponent();
        }

        void showAllClients()
        {
            service = new ServiceReference1.Service1Client();
            var allClients = service.GetClients();

            DataTable tb = new DataTable();
            tb.Columns.Add("Nume");
            tb.Columns.Add("Prenume");
            tb.Columns.Add("Adresa");
            tb.Columns.Add("Localitate");
            tb.Columns.Add("Judet");
            tb.Columns.Add("Telefon");
            tb.Columns.Add("Email");

            foreach (var a in allClients)
            {
                
                tb.Rows.Add(a.Nume, a.Prenume, a.Adresa, a.Localitate, a.Judet, a.Telefon, a.Email);
            }

            dataGrid.DataContext = tb.DefaultView;

            return;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            showAllClients();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            service = new ServiceReference1.Service1Client();
            Client a = new Client();
            a.Nume = tBNume.Text;
            a.Prenume = tbPrenume.Text;
            a.Adresa = tbAdresa.Text;
            a.Localitate = tbLocalitate.Text;
            a.Judet = tbJudet.Text;
            a.Telefon = tbTelefon.Text;
            a.Email = tbEmail.Text;

            service.AddClient(a);

        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {

               DataRowView dataRowView = (DataRowView)dataGrid.SelectedItem;
               Client x = service.GetClientbyName(dataRowView[0].ToString(), dataRowView[1].ToString());
               ClientID = x.ClientId;
                tBNume.Text = x.Nume;
                tbPrenume.Text = x.Prenume;
                tbAdresa.Text = x.Adresa;
                tbLocalitate.Text = x.Localitate;
                tbEmail.Text = x.Email;
                tbJudet.Text = x.Judet;
                tbTelefon.Text = x.Telefon;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Client a = new Client();
            a.ClientId = ClientID;
            a.Nume = tBNume.Text;
            a.Prenume = tbPrenume.Text;
            a.Adresa = tbAdresa.Text;
            a.Localitate = tbLocalitate.Text;
            a.Judet = tbJudet.Text;
            a.Telefon = tbTelefon.Text;
            a.Email = tbEmail.Text;

            service.UpdateClient(a);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Client a = new Client();
            a.ClientId = ClientID;
            a.Nume = tBNume.Text;
            a.Prenume = tbPrenume.Text;
            a.Adresa = tbAdresa.Text;
            a.Localitate = tbLocalitate.Text;
            a.Judet = tbJudet.Text;
            a.Telefon = tbTelefon.Text;
            a.Email = tbEmail.Text;

            service.DeleteClient(a);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {

            var allCars = service.GetAutomobils(ClientID);

            DataTable tb = new DataTable();
            tb.Columns.Add("AutoId");
            tb.Columns.Add("NumarAuto");
            tb.Columns.Add("SasiuId");
            tb.Columns.Add("SerieSasiu");
            
            foreach (var a in allCars)
            {

                tb.Rows.Add(a.AutoId, a.NumarAuto, a.SasiuId, a.SerieSasiu);
            }

            dataGrid.DataContext = tb.DefaultView;


        }
    }
}
