using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoPOO
{
    class Admin : Superadmin
    {
        //********ATRIBUTOS***********
        //Los de usuario y superadmin

        //********CONSTRUCTOR***********
        public Admin()
        {
            SetRol(2);
        }
        override public void SetNombre() 
        {
            this.nombre = Solicitar("Ingrese el nombre del administrador.");
        }
        public override void EliminarAdmin() //Override para que no se pueda eliminar administradores
        {
            Console.WriteLine("Un administrador no puede eliminar a otro.");
        }

        public override void AgregarAdmin() //Override para que no pueda agregar administradores
        {
            Console.WriteLine("Un administrador no puede agregar a otro.");
        }

        public override int GetLine(string nombreEmpresa, string nombreArchivo)
        {
            return base.GetLine(nombreEmpresa, nombreArchivo);
        }

    }
}
