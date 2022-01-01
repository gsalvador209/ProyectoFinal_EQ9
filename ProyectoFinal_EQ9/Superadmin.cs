using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProyectoPOO
{
    public class Superadmin : Usuario
    {
        //****ATRIBUTOS****
        protected string celular;
        protected string email;
        protected int numTrabajador;
        protected string dependencia;


        //***CONSTRUCTOR****
        public Superadmin() {
            SetRol(1);
        }

        //***MÉTODOS****
        //Setters y Getters

        override public void SetNombre()
        {
            this.nombre = Solicitar("Ingrese el nombre del superadministrador.");
        }
        public void SetCelular()
        {
            this.celular = Solicitar("Ingrese el número de celular");
        }
        public void SetEmail()
        {
            this.email = Solicitar("Ingrese el email");
        }
        public void SetNumTrabajador()
        {
            int num;
            while (true)
            {
                try
                {
                    num = Convert.ToInt32(Solicitar("Ingrese el número de trabajador"));
                    this.numTrabajador = num;
                    return;
                }
                catch
                {
                    Console.WriteLine("Solo puede ingresar dígitos");
                }
            }
        }
        public void SetDependencia()
        {
            this.dependencia = Solicitar("Ingrese la dependencia");
        }
        public string GetCelular() 
        { 
            return celular;
        }
        public string GetEmail() 
        { 
            return email; 
        }
        public int GetNumTrabajador()
        {
            return numTrabajador;
        }
        public string GetDependencia()
        {
            return dependencia;
        }

        public void Serializar(string archivo) //Convierte el objeto con sus atributos a una cadena de texto y lo almacena en un archivo
        {
            try
            {
                File.AppendAllText(archivo, (nombre + "|" + celular + "|" + email + "|" +
                    numTrabajador + "|" + dependencia + "|" + usuario + "|" + contraseña + "\n"));
            }
            catch
            {
                Console.WriteLine("Error al generar el administrador");

                return;
            }
            Console.WriteLine("Aministrador guardado correctamente.");
        }

        virtual public void DesSerializar(string texto) //A partir de texto, decodifica a un objeto de tipo superadmin
        {
            string[] arreglo = texto.Split('|');
            this.nombre = arreglo[0];
            this.celular = arreglo[1];
            this.email = arreglo[2];
            this.numTrabajador = Convert.ToInt32(arreglo[3]);
            this.dependencia = arreglo[4];
            this.usuario = arreglo[5];
            this.contraseña = arreglo[6];

        }

        virtual public void AgregarAdmin() //Agrega un admin nuevo solicitando cada atributo
        {
            Admin ad = new Admin();
            
            ad.SetNombre();
            ad.SetCelular();
            ad.SetEmail();
            ad.SetNumTrabajador();
            ad.SetDependencia();
            while (true)
            {
                ad.SetUsuario();
                //Console.WriteLine("Verificando si " + ad.GetUsuario() + " esá disponible.");
                if((ad.GetLine(ad.GetUsuario(), "admin.txt") !=-1)||(ad.GetLine(ad.GetUsuario(), "superadmin.txt")!=-1)||(ad.GetLine(ad.GetUsuario(), "empresas.txt")!=-1))
                {
                    Console.WriteLine("Ese usuario no está disponible.");
                }
                else
                {
                    break;
                }
            }
            ad.SetContraseña();
            ad.Serializar("admin.txt");
        }

        virtual public void EliminarAdmin() //Elimina un administrador a partir de su usuario
        {
            string usuario;
            int linea;
            
            Console.WriteLine("Ingresa el usuario que deseas eliminar.");
            usuario = Console.ReadLine();
            linea = GetLine(usuario,"admin.txt");
            if (linea == -1)
            {
                Console.WriteLine("No existe ese usuario");
                return;
            }

            if (this.DeleteLine(linea, "admin.txt") != -1)
                Console.WriteLine("Se ha borrado el admin exitosamente.");
            else
                Console.WriteLine("Ha ocurrido un error inesperado. El archivo no se pudo abrir.");

        }
    }
}
