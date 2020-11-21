﻿using Semana8DannyCardenas.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana8DannyCardenas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection conn;
        private ObservableCollection<Estudiante> _TablaEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            this.conn = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var resultadoRegistros = await conn.Table<Estudiante>().ToListAsync();
            _TablaEstudiante = new ObservableCollection<Estudiante>(resultadoRegistros);
            ListaUsuario.ItemsSource = _TablaEstudiante;
            base.OnAppearing();
        }

        private void ListaUsuario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiante)e.SelectedItem;
            var item = Obj.id.ToString();
            int ID = Convert.ToInt32(item);

            try 
            {
                Navigation.PushAsync(new Elemento(ID));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}