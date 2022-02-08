using System;
using System.Windows;
using System.Linq;
using System.Collections.Generic;
using Pablo_Burgos_Ap1_p1.BLL;
using Pablo_Burgos_Ap1_p1.Entidades;

namespace Pablo_Burgos_Ap1_p1.UI.Registros
{
    public partial class rProducto : Window
    {
        private Productos productos = new Productos();
        public rProducto()
        {
            InitializeComponent();
            this.DataContext = productos;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = productos;
        }

        private void Limpiar()
        {
            this.productos = new Productos();
            this.DataContext = productos;
        }

        private bool Validar()
        {
            bool esValido = true;
            if(string.IsNullOrWhiteSpace(Convert.ToString(productos.ProductosId)))
            {
                esValido = false;
                MessageBox.Show("Introduce el id del producto..");
            } 
            else if (string.IsNullOrWhiteSpace(productos.Descripcion))
            {
                esValido = false;
                MessageBox.Show("Introduce la descripcion del producto..");
            }
            else if (string.IsNullOrWhiteSpace(productos.Existencia))
            {
                esValido = false;
                MessageBox.Show("Introduce la existencia");
            }
            else if(string.IsNullOrWhiteSpace(Convert.ToString(productos.Costo)))
            {
                esValido = false;
                MessageBox.Show("Introduce el costo");

            }



            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontro = ProductosBLL.Buscar(productos.ProductosId);

            if(encontro != null)
            {
                productos = encontro;
                Cargar();
            }
            else
            {
                MessageBox.Show("No encontro el producto");
            }
            
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();     
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if(!Validar())
                return;

            paso = ProductosBLL.Guardar(productos);
            if(paso)
            {
                Limpiar();
                MessageBox.Show("Producto guardado..");
            }
            else
            {
                MessageBox.Show("No se pudo guardar el producto");

            }
            
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProductosBLL.Eliminar(productos.ProductosId))
            {
                Limpiar();
                MessageBox.Show("Producto agregado..");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar..");

            }
            
        }
    }
}