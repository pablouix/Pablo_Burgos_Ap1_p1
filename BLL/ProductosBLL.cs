using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pablo_Burgos_Ap1_p1.Entidades;


namespace Pablo_Burgos_Ap1_p1.BLL
{
    public class ProductosBLL
    {
        public static bool Existe(int ProductosId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                paso = contexto.Productos.Any(p => p.ProductosId == ProductosId);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool ExisteDescripcion(string Descripcion)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                paso = contexto.Productos.Any(p => p.Descripcion == Descripcion);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Productos Buscar(int ProductosId)
        {
            Contexto contexto = new Contexto();
            Productos? productos;
            try
            {
                productos = contexto.Productos.Find(ProductosId);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return productos;
        }

        public static bool Guardar(Productos productos)
        {
            if(!Existe(productos.ProductosId) || !ExisteDescripcion(productos.Descripcion))
                return Insertar(productos);
            else
                return false;
        }

        public static bool Eliminar(int ProductosId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var productos = contexto.Productos.Find(ProductosId);

                if(productos != null)
                {
                    contexto.Productos.Remove(productos);
                    paso = contexto.SaveChanges() > 0;
                }

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Insertar(Productos productos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Productos.Add(productos);
                paso = contexto.SaveChanges() > 0;

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso; 
        }

        public static List<Productos> GetLista(Expression<Func<Productos, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Productos> listaProductos = new List<Productos>();

            try
            {
                listaProductos = contexto.Productos.Where(criterio).ToList();

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return listaProductos;

        }
    }
}