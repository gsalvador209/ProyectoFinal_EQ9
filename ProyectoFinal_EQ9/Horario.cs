using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProyectoPOO
{
    public class Horario
    {
        private int IdHorario;
        private string nombreSala;
        private string[] horario = new string[] { "9:00 - 10:00 am", "10:00 - 11:30 am", "12:00 - 2:00 pm", "2:10 - 3:30 pm", "3:40 - 5:00 pm", "5:00 - 7:00pm" };
        private string empresaSala; // Nombre que aparto la sala
        private string nombreConferencia;

        LinkedList<Sala> Salas = new LinkedList<Sala>(); // ! Nuevo
        LinkedList<Ponente> Agendas = new LinkedList<Ponente>(); // ! Nuevo

        // Métodos Getters y Setters

        public Horario()
        { // ! Nuevo
            //Añadiendo los horarios en las salas
            Salas.AddFirst(new Sala(100, "Sala 1"));
            Salas.AddLast(new Sala(50, "Sala 2"));
            Salas.AddLast(new Sala(50, "Sala 3"));
            Salas.AddLast(new Sala(75, "Sala 4"));
            Salas.AddLast(new Sala(100, "Sala 5"));
            Salas.AddLast(new Sala(10, "Ctro 1"));
            Salas.AddLast(new Sala(10, "Ctro 1"));
        }
        public int getIdHorario()
        {
            return this.IdHorario;
        }

        public void setIdHorario(int IdHorario)
        {
            this.IdHorario = IdHorario;
        }

        public string getHorario()
        {
            string cadenaHorario = "\n Horarios:\n";
            int contador = 1;
            foreach (var item in horario)
            {
                cadenaHorario += " (" + contador + ") " + item + "\n";
                contador++;
            }
            return cadenaHorario;
        }

        public string getNombreSala()
        {
            return this.nombreSala;
        }

        public void setNombreSala(string nombreSala)
        {
            this.nombreSala = nombreSala;
        }

        public string getEmpresaSala()
        {
            return this.empresaSala;
        }

        public void setEmpresaSala(string empresaSala)
        {
            this.empresaSala = empresaSala;
        }

        public string getNombreConferencia()
        {
            return this.nombreConferencia;
        }

        public void setNombreConferencia(string nombreConferencia)
        {
            this.nombreConferencia = nombreConferencia;
        }

        // Agregar estos métodos

        public void horarioCompleto()
        {
            int i = 1;
            Console.Write("\n * Nota: Ctro = Centro\n\n     ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" Horario: " + "\t");
            Console.ResetColor();
            foreach (var item in horario)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(item + "   ");
                Console.ResetColor();
            }
            Console.Write("\n");
            foreach (var item in Salas)
            {
                Console.WriteLine("   "+item.getNombreSala() + "\t" + item.getValidacion());
                i++;
            }
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(" *** Datos de las conferencias ***");
            Console.ResetColor();
            foreach (var item in Agendas)
            {
                Console.WriteLine(item.toString());
            }
        }

        public void descargarHorario()
        {
            //Descargarlo en txt
            string path = "./Horario.txt";
            string texto = "* Nota: Ctro = Centro\n\n" + "Horario: " + "\t";
            foreach (var item in horario)
            {
                texto += item + "\t";
            }
            texto += "\n";
            foreach (var item in Salas)
            {
                texto += item.getNombreSala() + "\t" + item.getValidacion();
            }

            texto += "\n*** Datos de las conferencias ***";

            foreach (var item in Agendas)
            {
                texto += item.toString() + "\n";
            }

            using (StreamWriter mylogs = File.AppendText(path))//se crea el archivo
            {
                mylogs.WriteLine(texto);
                mylogs.Close();
            }
        }
        public void asignarHorario()
        {
            LinkedList<int> salasDisponibles = new LinkedList<int>();
            Boolean swap = true;
            int i,disponibles = 0;
            int horarioOPC = 0;
            int numSala = 0;
            int aforoSala = 0;
            do
            {
                horarioCompleto();
                Console.WriteLine(getHorario());
                do
                {
                    Console.Write(" Opcion:  ");
                    horarioOPC = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                } while (horarioOPC < 1 || horarioOPC > horario.Length);
                
                //Introduce la sala
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Salas disponibles:");
                Console.ResetColor();
                Console.WriteLine();

                for (i = 0; i < Salas.Count(); i++)
                {
                    if (Salas.ElementAt(i).salasDisponibles(horarioOPC,disponibles))
                    {
                        disponibles += 1;
                        salasDisponibles.AddLast(i);
                    }
                }

                if (salasDisponibles.Count() != 0)
                {
                    Console.Write(" ! Por el momento las otras salas se encuentran ocupadas. \n");
                    do
                    {
                        Console.Write("\n Selecciona la sala: ");
                        numSala = int.Parse(Console.ReadLine()); // ! Se utilizara para modificar el index
                    } while (numSala < 1 || numSala > disponibles);

                    swap = Salas.ElementAt(salasDisponibles.ElementAt(numSala - 1)).setHorario(horarioOPC -1);
                    aforoSala = Salas.ElementAt(salasDisponibles.ElementAt(numSala - 1)).getAforo();
                }
                else
                {
                    Console.WriteLine(" ¡ Lo sentimos, todas las salas estan ocupadas ! :(");
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n Presione Enter para continuar....");
                    Console.ResetColor();
                    Console.ReadLine();
                }
                
            } while (swap);

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n Agrega los datos del Ponente.");
            Console.ResetColor();
            Console.Write("\n Nombre del ponente:  ");
            string nombrePonente = Console.ReadLine();
            Console.Write("\n Nombre de la conferencia: ");
            string nombreConferencia = Console.ReadLine();
            Console.Write("\n Tiempo de la conferencia (colocarlo en horas 'hrs' o minutos 'min'): ");
            string tiempoConferencia = Console.ReadLine();
            int ciclo = 0;
            int aforoConferencia;
            do
            {
                Console.Write("\n Aforo de la conferencia (max. "+aforoSala+" personas): ");
                aforoConferencia = int.Parse(Console.ReadLine());

                if (aforoConferencia <= aforoSala)
                    ciclo = 1;
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n El aforo de la conferencia es mayor al aforo de la sala.");
                    Console.ResetColor();
                }
                    
            } while (ciclo != 1);

            Agendas.AddLast(new Ponente(nombrePonente, nombreConferencia, tiempoConferencia, Salas.ElementAt(salasDisponibles.ElementAt(numSala - 1)).getNombreSala(), horario[horarioOPC-1], aforoConferencia));

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n ¡ La "+ Salas.ElementAt(salasDisponibles.ElementAt(numSala - 1)).getNombreSala()+" fue apartada con exito en el horario "+horario[horarioOPC-1]+" !");
            Console.ResetColor();
        }
    }
}