using System.Windows;
using System.Linq;
using System.Collections.Generic;
using Pablo_Burgos_Ap1_p1.BLL;
using Pablo_Burgos_Ap1_p1.Entidades;
using System;

namespace Pablo_Burgos_Ap1_p1.UI.Consultas
{
    public partial class cProducto : Window
    {

        public cProducto()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
           var listaProductos = new List<Productos>();

            if(string.IsNullOrWhiteSpace(CriterioTextBox.Text))
                listaProductos = ProductosBLL.GetLista(p => true);
            else
            {
                bool esID = Int32.TryParse(CriterioTextBox.Text, out int id);

                if(esID)
                    listaProductos = ProductosBLL.GetLista(p => p.ProductosId == Convert.ToInt32(CriterioTextBox.Text));
                else
                    listaProductos = ProductosBLL.GetLista(p => p.Descripcion == CriterioTextBox.Text);
            }

        
            ProductosDataGrid.ItemsSource = null;
            ProductosDataGrid.ItemsSource = listaProductos;
        }
    }
}