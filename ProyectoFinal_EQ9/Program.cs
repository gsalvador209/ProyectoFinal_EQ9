using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            int op,repetir,correcto = 0;
            Superadmin sa = new Superadmin();
            Admin ad = new Admin();
            Empresa emp = new Empresa();

            do
            {
                Console.Clear();
                Console.Write("\n ¿Quieres iniciar sesion?\n\n\t");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("(1)");
                Console.ResetColor();
                Console.Write(" Si\t");
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write("(2)");
                Console.ResetColor();
                Console.Write(" No\n\n");
                Console.Write("Opcion: ");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        // VERIFICA EL TIPO DE USUARIO QUE QUIERE INGRESAR
                        Console.Clear();
                        Console.Write("\n Seleccione el tipo de usuario que desea ingresar:\n\n\t");
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("(1)");
                        Console.ResetColor();
                        Console.Write(" Admin\t");
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write("(2)");
                        Console.ResetColor();
                        Console.Write(" Empresa\n\n");
                        Console.Write("Opcion: ");
                        op = Convert.ToInt32(Console.ReadLine());
                        switch (op)
                        {
                            // USUARIO TIPO ADMIN
                            case 1:
                                do
                                {
                                    Console.Clear();
                                    // SI LOS DATOS SON INCORRECTOS VUELVE A INICIAR SESION
                                    switch (iniciarSesion())
                                    {
                                        case 0:
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.WriteLine(" Los datos ingresados son incorrectos");
                                            Console.ResetColor();
                                            Console.Write("\n Presione Enter para continuar.....");
                                            Console.ReadLine();
                                            correcto = 0;
                                            break;
                                        case 1:
                                            //MENU DE SUPERADMIN

                                            correcto = 1;
                                            break;
                                        case 2:
                                            //MENU ADMIN
                                            correcto = 1;
                                            break;
                                    }
                                } while (correcto == 0);
                                break;
                            // USUARIO TIPO EMPRESA
                            case 2:
                                Console.Clear();
                                Console.Write("\n ¿Ya cuenta con una cuenta?\n" +
                                    " (1) Si\t(2) No\n Opcion: ");
                                op = Convert.ToInt32(Console.ReadLine());
                                switch (op)
                                {
                                    case 1:
                                        do
                                        {
                                            switch (iniciarSesion())
                                            {
                                                case 0:
                                                    Console.BackgroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(" Los datos ingresados son incorrectos");
                                                    Console.ResetColor();
                                                    Console.Write("\n Presione Enter para continuar.....");
                                                    Console.ReadLine();
                                                    correcto = 0;
                                                    break;
                                                case 3:
                                                    // MENU EMPRESA
                                                    correcto = 1;
                                                    break;
                                            }
                                        } while (correcto == 0);
                                        break;
                                    // CREA CUENTA DE EMPRESA
                                    case 2:
                                        crearCuenta();
                                        break;
                                }
                                break;
                        }
                        repetir = 1;
                        break;
                    case 2:
                        Console.WriteLine("\n Saliendo del programa...");
                        repetir = 0;
                        break;
                    default:
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Seleccione una opcion valida...");
                        Console.ResetColor();
                        repetir = 1;
                        break;
                }
                Console.Write("\n Presione Enter para continuar....");
                Console.ReadLine();
            } while (repetir == 1);

            int iniciarSesion()
            {
                Usuario user = new Usuario();
                String username, pasword,usuarioSerializado;
                Console.Write("\n Username: ");
                username = Console.ReadLine();
                Console.Write("\n Contraseña: ");
                pasword = Console.ReadLine();

                //BUSCA EN QUE ARCHIVO SE ECUENTRA EL USUARIO EN CASO CONTRARIO REGRESA UN 0
                if (user.VerificarUsuarioyContraseña(username, pasword, "superadmin.txt", 1))
                {
                    
                    usuarioSerializado = user.GetStringLine(user.GetLine(username,"superadmin.txt"),"superadmin.txt");
                    sa.DesSerializar(usuarioSerializado);

                    Console.WriteLine("\n Bienvenidx superadministrador, " + sa.GetNombre());
                    return 1;
                }
                else if (user.VerificarUsuarioyContraseña(username, pasword, "admin.txt", 2))
                {
                    usuarioSerializado = user.GetStringLine(user.GetLine(username, "admin.txt"), "admin.txt");
                    ad.DesSerializar(usuarioSerializado);

                    Console.WriteLine("\n Bienvenidx administrador, " + ad.GetNombre());
                    return 2;
                }
                else if (user.VerificarUsuarioyContraseña(username, pasword, "empresa.txt", 3))
                {
                    usuarioSerializado = user.GetStringLine(user.GetLine(username, "empresa.txt"), "empresa.txt");
                    emp.DesSerializar(usuarioSerializado);
                    Console.WriteLine("\n Bienvenidx, " + emp.GetNombre());
                    return 3;
                }
                return 0;
            }
        }

        static void crearCuenta()
        {

        }
    }
}
