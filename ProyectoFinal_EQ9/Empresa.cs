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
        public string GetUser()
        {
            return GetUsuario();
        }
        public string GetPasword()
        {
            return GetContraseña();
        }
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
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" Error al guardar la empresa.");
                Console.ResetColor();
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
        public void ActualizarInfo(string empresa, string nombre, string email, string celular)
        {
            this.nombre = empresa;
            this.rep.nombre = nombre;
            this.rep.celular = celular;
            this.rep.email = email;

            Serializar("empresas.txt");

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Los datos han sido actualizados correctamente");
            Console.ResetColor();
        }
    }
}
