using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProyectoPOO
{
    class Empresa:Usuario
    {
        //*****ATRIBUTOS****
        public RepEmpresa rep = new RepEmpresa();
        
        //****CONSTRUCTOR*******
        public Empresa()
        {
            SetRol(3);
        }
        //*****MÉTODOS*****
        override public void SetNombre()
        {
            this.nombre = Solicitar(" Ingrese el nombre de la empresa: ");
        }
        
        public void Serializar(string archivo)
        {
            try
            {
                File.AppendAllText(archivo, (rep.nombre + "|" + rep.email  + "|" + rep.celular  + "|" + nombre +
                   "|" + usuario + "|" + contraseña + "\n"));
            }
            catch
            {
                Console.WriteLine("Error al guardar la empresa");

                return;
            }
        }
        
        public void DesSerializar(string texto)
        {
            string[] arreglo = texto.Split('|');
            
            this.rep.nombre = arreglo[0];
            this.rep.email = arreglo[1];
            this.rep.celular = arreglo[2];
            this.nombre = arreglo[3];
            this.usuario = arreglo[4];
            this.contraseña = arreglo[5];
            
        }
        public Empresa infoUser(string username)
        {
            Empresa emp = new Empresa();

            string temp = "", user = "";
            try
            {
                StreamReader leer = new StreamReader("empresas.txt");
                for (int i = 0; !leer.EndOfStream; i++)
                {
                    temp = leer.ReadLine();
                    emp = new Empresa();
                    emp.DesSerializar(temp);
                    user = emp.GetUsuario();
                    if (username.Equals(user))
                    {
                        leer.Close();
                        return emp;
                    }
                }
                leer.Close();
                return null;
            }
            catch
            {
                Console.WriteLine("\n No se encontro el usuario. ");
                return null;
            }
        }
    }
}
