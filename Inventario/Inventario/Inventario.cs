using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    class Inventario
    {

        private Producto inicial;

        public void agregar(string codigo, string nombre, int cantidad, double precio)
        {
            if(inicial == null){
                inicial = new Producto(codigo, nombre, cantidad, precio);
            }else{
                Producto actual = inicial;
                while(actual.siguiente != null){
                    actual = actual.siguiente;
                }
                actual.siguiente = new Producto(codigo, nombre, cantidad, precio); ;
            }
        }

        public void borrar(string cod)
        {
            Producto actual = inicial;
            if (actual.getCodigo().Equals(cod))
            {
                inicial = actual.siguiente;
            }
            else
            {
                while (actual.siguiente != null)
                {
                    if (actual.siguiente.getCodigo().Equals(cod))
                    {
                        actual.siguiente = actual.siguiente.siguiente;
                        return;
                    }
                    else
                    {
                        actual = actual.siguiente;
                    }
                }
            }
        }

        public void insertar(int posicion, string codigo, string nombre, int cantidad, double precio)
        {
            Producto actual = inicial;
            if (posicion == 0)
            {
                Producto temp = inicial;
                inicial = new Producto(codigo, nombre, cantidad, precio);
                inicial.siguiente = temp;
            }
            else
            {
                for (int i = 0; i < posicion - 1; i++)
                {
                    actual = actual.siguiente;
                }
                Producto temp = actual.siguiente;
                actual.siguiente = new Producto(codigo, nombre, cantidad, precio);
                actual.siguiente.siguiente = temp;
            }
        }

        public Producto buscar(string codigo)
        {
            Producto actual = inicial;
            while (actual != null)
            {
                if (actual.getCodigo().Equals(codigo))
                {
                    return actual;
                }
                else
                {
                    actual = actual.siguiente;
                }
            }
            return null;
        }

        public String reporte()
        {
            String s = "";
            Producto actual = inicial;
            while (actual != null)
            {
                s += actual.ToString() + Environment.NewLine;
                actual = actual.siguiente;
            }
            return s;
        }

    }
}
