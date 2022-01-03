using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProyectoPOO 
{
     public class Usuario
    {
        //****ATRIBUTOS*****
        protected int rol; //1: Superadmin 2:Admin 3:Empresa
        protected string nombre;
        protected string usuario; //No confundir con clase Usuario, este es username
        protected string contraseña;

        //***CONSTRUCTOR***     //No debe usarse
        public Usuario()
        {

        }

        //********MÉTODOS********
        //***Setters y Getters
        protected void SetRol(int rol){   this.rol = rol;}
        virtual public void SetNombre() { 
            this.nombre = Solicitar(" Ingrese el nombre de usuario: "); 
        }
        virtual public void SetUsuario()
        {
            do
            {
                this.usuario = Solicitar(" Ingrese un username: ");
            } while (Verificar(this.usuario));
        }
        public void SetContraseña()
        {
            this.contraseña = Solicitar(" Ingrese una nueva constraseña: ");
        }
        public int GetRol() { 
            return rol;
        }
        public string GetNombre() {
            return nombre;
        }
        protected string GetUsuario() { 
            return usuario; 
        }
        protected string GetContraseña() {
            return contraseña; 
        }

        public string Solicitar(string solicitud)  //Pide la entrada de un string no vacío. Imprime el argumento ingresado
        {
            string dato = "";
            Console.Write(solicitud);
            while (true)
            {
                dato=Console.ReadLine();
                
                if (dato.Contains('|'))
                {
                    Console.WriteLine("No puede contener el caracter '|'");
                }else if (!dato.Equals(""))
                    break;
            }
            return dato;
        }

        public bool VerificarUsuarioyContraseña(string user,string pass,string nombreArchivo,int rol)
        {   //Verifica que el usuario y contraseña registrados en nombreArchivo coincidan, depende del rol
            Superadmin sA;
            Admin aD; 
            Empresa emp;
            
            string temp, cmpUser = "", cmpPass = "";
            try {
                StreamReader leer = new StreamReader(nombreArchivo);
                switch (rol)
                {
                    case 1:
                        for (int i = 0; !leer.EndOfStream; i++)
                        {
                            temp = leer.ReadLine();
                            sA = new Superadmin();
                            sA.DesSerializar(temp);
                            cmpUser = sA.GetUsuario();
                            cmpPass = sA.GetContraseña();
                            if (cmpUser.Equals(user) && cmpPass.Equals(pass))
                            {
                                leer.Close();
                                return true;
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; !leer.EndOfStream; i++)
                        {
                            temp = leer.ReadLine();
                            aD = new Admin();
                            aD.DesSerializar(temp);
                            cmpUser = aD.GetUsuario();
                            cmpPass = aD.GetContraseña();
                            if (cmpUser.Equals(user) && cmpPass.Equals(pass))
                            {
                                leer.Close();
                                return true;
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; !leer.EndOfStream; i++)
                        {
                            temp = leer.ReadLine();
                            emp = new Empresa();
                            emp.DesSerializar(temp);
                            cmpUser = emp.GetUsuario();
                            cmpPass = emp.GetContraseña();
                            if (cmpUser.Equals(user) && cmpPass.Equals(pass))
                            {
                                leer.Close();
                                return true;
                            }

                        }
                        break;
                }
                leer.Close();
            }
            catch
            {
            }
            return false;
        }

        virtual public int GetLine(string username, string nombreArchivo) //Obtiene el número de linea donde se encuentra el username en un archivo
        {
            string linea,user;
            Superadmin sp = new Superadmin();
            Admin ad = new Admin();
            Empresa em = new Empresa();
            try
            {
                StreamReader f = new StreamReader(nombreArchivo);

                if (nombreArchivo.Equals("admin.txt"))
                {
                    for (int i = 0; !f.EndOfStream; i++)
                    {
                        linea = f.ReadLine();
                        ad.DesSerializar(linea);
                        user = ad.GetUsuario();
                        if (user.Contains(username))
                        {
                            f.Close();
                            return i;
                        }
                    }
                }
                else if (nombreArchivo.Equals("superadmin.txt"))
                {
                    for (int i = 0; !f.EndOfStream; i++)
                    {
                        linea = f.ReadLine();
                        sp.DesSerializar(linea);
                        user = sp.GetUsuario();
                        if (user.Contains(username))
                        {
                            f.Close();
                            return i;
                        }
                    }
                }
                else if (nombreArchivo.Equals("empresas.txt"))
                {
                    for (int i = 0; !f.EndOfStream; i++)
                    {
                        linea = f.ReadLine();
                        em.DesSerializar(linea);
                        user = em.GetUsuario();
                        if (user.Contains(username))
                        {
                            f.Close();
                            return i;
                        }
                    }
                }
                f.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("No se encontraron los archivos necesarios: "+ e);

            }
            return -1;
        }
        public string GetStringLine(int line, string nombreArchivo) //Obtiene la linea indicada de un archivo
        {
            string linea = "";
            try
            {
                StreamReader f = new StreamReader(nombreArchivo);
                for (int i = 0; !f.EndOfStream && i<=line; i++)
                {
                    linea = f.ReadLine();
                }
                f.Close();
            }
            catch
            {

            }
            return linea;
        }
        public int DeleteLine(int line, string nombreArchivo) //Borra la linea indicada de un archivo
        {
            string[] backupLines;
            int i;
            try
            {
                backupLines = File.ReadAllLines(nombreArchivo);

                //*********ESTO BORRA EL ARCHIVO***************
                StreamWriter sw = File.CreateText(nombreArchivo);
                sw.Close();
                //********************************************

                for (i = 0; i < backupLines.Length; i++)
                {
                    if (i != line)
                    {
                        File.AppendAllText(nombreArchivo, backupLines[i] + "\n");
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("\n "+e.Message);
                return -1;
            }
        }
        public Boolean Verificar(string username)
        {
            int ad,sp,em;
            sp = GetLine(username, "superadmin.txt");
            ad = GetLine(username, "admin.txt");
            em = GetLine(username, "empresas.txt");
            if (sp != -1 || ad != -1 || em != -1)
            {
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" Este usuario ya esta registrado, eliga otro.\n");
                Console.ResetColor();
                return true;
            }
            return  false;
        }
    }
}
