using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoPOO
{
    class Empresa:Usuario
    {
        //*****ATRIBUTOS****
        //RepEmpresa rep;
        
        //****CONSTRUCTOR*******
        public Empresa()
        {
            SetRol(3);
        }
        //*****MÉTODOS*****
        override public void SetNombre()
        {
            this.nombre = Solicitar("Ingrese el nombre de la empresa.");
        }

        /*
        public void Serializar()
        {
            try
            {
                File.AppendAllText(archivo, (rep.nombre + "|" + rep.email  + "|" + rep.celular  + "|" + nombre + "|" +
                   "|" + usuario + "|" + contraseña + "\n"));
            }
            catch
            {
                Console.WriteLine("Error al guardar la empresa");

                return;
            }
            Console.WriteLine("Empresa registrada correctamente.");

        }
        */
        public void DesSerializar(string texto)
        {
            string[] arreglo = texto.Split('|');
            /*
            this.rep.nombre = arreglo[0];
            this.rep.email = arreglo[1];
            this.rep.celular = arreglo[2];
            this.nombre = arreglo[3];
            this.usuario = arreglo[4];
            this.contraseña = arreglo[5];
            */
        }
        
    }
}
