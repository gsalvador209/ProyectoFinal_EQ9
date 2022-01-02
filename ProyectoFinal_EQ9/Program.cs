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
            int op, repetir, correcto = 0;
            string username, pasword;
            Superadmin sa = new Superadmin();
            Admin ad = new Admin();
            Empresa emp = new Empresa();
            Usuario user = new Usuario();
            String usuarioSerializado;

            do
            {
                Console.Clear();
                Console.Write("\n\n\n\t");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("(1)");
                Console.ResetColor();
                Console.Write(" Iniciar sesión\t");
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write("(2)");
                Console.ResetColor();
                Console.Write(" Salir y Acerca De\n\n");
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
                                    Console.Write("\n Username: ");
                                    username = Console.ReadLine();
                                    Console.Write("\n Contraseña: ");
                                    pasword = Console.ReadLine();
                                    switch (iniciarSesion(username, pasword))
                                    {
                                        case 0:
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.WriteLine(" Los datos ingresados son incorrectos");
                                            Console.ResetColor();
                                            do
                                            {
                                                Console.Write("\n ¿Quieres salir?\n\n\t");
                                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("(1)");
                                                Console.ResetColor();
                                                Console.Write(" Si\t");
                                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("(2)");
                                                Console.ResetColor();
                                                Console.Write(" No\n\n");
                                                Console.Write("Opcion: ");
                                                op = Convert.ToInt32(Console.ReadLine());
                                            } while (op < 1 && op > 2);
                                            if (op == 1)
                                            {
                                                correcto = 1;
                                            }
                                            else if (op == 2)
                                            {
                                                correcto = 0;
                                            }
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
                                Console.Write("\n ¿Ya tiene una cuenta?\n\n\t");
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                Console.Write("(1)");
                                Console.ResetColor();
                                Console.Write(" Si\t");
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Write("(2)");
                                Console.ResetColor();
                                Console.Write(" No\n\n");
                                Console.Write("Opcion: ");
                                op = Convert.ToInt32(Console.ReadLine());
                                switch (op)
                                {
                                    case 1:
                                        do
                                        {
                                            Console.Clear();
                                            Console.Write("\n Username: ");
                                            username = Console.ReadLine();
                                            Console.Write("\n Contraseña: ");
                                            pasword = Console.ReadLine();
                                            switch (iniciarSesion(username, pasword))
                                            {
                                                case 0:
                                                    Console.WriteLine();
                                                    Console.BackgroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(" Los datos ingresados son incorrectos");
                                                    Console.ResetColor();
                                                    do
                                                    {
                                                        Console.Write("\n ¿Quieres salir?\n\n\t");
                                                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("(1)");
                                                        Console.ResetColor();
                                                        Console.Write(" Si\t");
                                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                                        Console.Write("(2)");
                                                        Console.ResetColor();
                                                        Console.Write(" No\n\n");
                                                        Console.Write("Opcion: ");
                                                        op = Convert.ToInt32(Console.ReadLine());
                                                    } while (op < 1 && op > 2);
                                                    if (op == 1)
                                                    {
                                                        correcto = 1;
                                                    }
                                                    else if (op == 2)
                                                    {
                                                        correcto = 0;
                                                    }
                                                    break;
                                                case 3:
                                                    // MENU EMPRESA
                                                    menuEmpresa(username);
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
                        // SALE DEL PROGRAMA
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n Saliendo del programa...");
                        Console.ResetColor();
                        Console.WriteLine("\n\nProyecto Final\nProgramación Orientada a Objetos"
                            + "\nGrupo 09 \nSemestre 2021-2 \nEquipo 9 \nIntegates:");
                        Console.WriteLine("1. Chávez Villanueva Giovanni Salvador\n" +
                            "2. Nava Alberto Vanessa\n" +
                            "3. Perez Lagunas Bernardo\n" +
                            "4. Pilares Garcia Heber Adan\n" +
                            "5. Quero Bautista Yaxca Alexa\n");
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
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write("\n Presione Enter para continuar....");
                Console.ResetColor();
                Console.ReadLine();
            } while (repetir == 1);
            int iniciarSesion(string un, string ps)
            {

                //BUSCA EN QUE ARCHIVO SE ECUENTRA EL USUARIO EN CASO CONTRARIO REGRESA UN 0
                if (user.VerificarUsuarioyContraseña(un, ps, "superadmin.txt", 1))
                {

                    usuarioSerializado = user.GetStringLine(user.GetLine(un, "superadmin.txt"), "superadmin.txt");
                    sa.DesSerializar(usuarioSerializado);

                    Console.WriteLine("\n Bienvenidx superadministrador, " + sa.GetNombre());
                    return 1;
                }
                else if (user.VerificarUsuarioyContraseña(un, ps, "admin.txt", 2))
                {
                    usuarioSerializado = user.GetStringLine(user.GetLine(un, "admin.txt"), "admin.txt");
                    ad.DesSerializar(usuarioSerializado);

                    Console.WriteLine("\n Bienvenidx administrador, " + ad.GetNombre());
                    return 2;
                }
                else if (user.VerificarUsuarioyContraseña(un, ps, "empresa.txt", 3))
                {
                    usuarioSerializado = user.GetStringLine(user.GetLine(un, "empresa.txt"), "empresa.txt");
                    emp.DesSerializar(usuarioSerializado);
                    Console.WriteLine("\n Bienvenidx, " + emp.GetNombre());
                    return 3;
                }
                return 0;
            }
        }

        
        static void crearCuenta()
        {
            Empresa empresa = new Empresa();
            Console.WriteLine("\n Ingrese los siguientes datos para crear la cuenta\n ");
            empresa.SetNombre();
            Console.WriteLine();
            empresa.SetUsuario();
            Console.WriteLine();
            empresa.SetContraseña();
            Console.Write("\n Ahora Ingrese los datos del representante de la empresa\n\n");
            empresa.rep.SetNombre();
            Console.WriteLine();
            empresa.rep.SetEmail();
            Console.WriteLine();
            empresa.rep.SetCelular();
            Console.WriteLine();
            empresa.Serializar("empresas.txt");

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(" Empresa registrada exitosamente !!!");
            Console.ResetColor();
        }
        static void menuEmpresa(string user)
        {
            Empresa emp = new Empresa();
            int repetir = 0, op;

            emp = emp.infoUser(user);

            if (emp != null)
            {
                do
                {
                    Console.Clear();
                    Console.Write("\n Hola ");
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Write(emp.rep.GetNombre());
                    Console.ResetColor();
                    Console.Write(" !!! \n\n Seleccione una opcion.\n\n\t");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write("(1)");
                    Console.ResetColor();
                    Console.Write(" Actualizar Datos\n\n\t");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write("(2)");
                    Console.ResetColor();
                    Console.Write(" Reservar Horarios\n\n\t");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write("(3)");
                    Console.ResetColor();
                    Console.Write(" Ver Horarios\n\n\t");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write("(4)");
                    Console.ResetColor();
                    Console.WriteLine(" Salir\n");
                    Console.Write(" Opcion: ");
                    op = Convert.ToInt32(Console.ReadLine());
                    Console.Write(" (1) Actualizar Datos\n\n" +
                        " (2) Reservar Horario\n\n" +
                        " (3) Ver Horarios\n\n" +
                        " (4) Salir\n\nOpcion: ");
                    op = Convert.ToInt32(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            repetir = 1;
                            break;
                    }
                } while (repetir == 0);
            }

            Console.ReadLine();
        }
    }
}

