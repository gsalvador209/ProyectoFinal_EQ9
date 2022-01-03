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
            Console.Clear();
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
            Boolean swap = true;
            int i,j = 1;
            int horarioOPC = 0;
            int numSala = 0;
            int aforoSala = 0;
            do
            {
                int contador = 0;
                horarioCompleto();
                Console.WriteLine(getHorario());
                Console.Write(" Opcion:  ");
                horarioOPC = int.Parse(Console.ReadLine());

                //Introduce la sala
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Salas disponibles:");
                Console.ResetColor();
                Console.WriteLine();

                for(i = 0;i < Salas.Count();i++)
                {
                    Salas.ElementAt(i).salasDisponibles(horarioOPC,j);
                    j += 1;
                }

                numSala = int.Parse(Console.ReadLine()); // ! Se utilizara para modificar el index

                foreach (var item in Salas)
                {
                    if (contador == (numSala - 1))
                    {
                        swap = item.setHorario(horarioOPC - 1);
                        aforoSala = item.getAforo();
                    }
                    contador++;
                }
            } while (swap);

            Console.Write("Nombre del ponente --> ");
            string nombrePonente = Console.ReadLine();
            Console.Write("Nombre de la conferencia --> ");
            string nombreConferencia = Console.ReadLine();
            Console.Write("Tiempo de la conferencia --> ");
            string tiempoConferencia = Console.ReadLine();
            int ciclo = 0;
            int aforoConferencia;
            do
            {
                Console.Write("Aforo de la conferencia --> ");
                aforoConferencia = int.Parse(Console.ReadLine());

                if (aforoConferencia < aforoSala)
                    ciclo = 1;
                else
                    Console.WriteLine("El aforo de la conferencia es mayor al aforo de la sala");
            } while (ciclo != 1);

            Agendas.AddLast(new Ponente(nombrePonente, nombreConferencia, tiempoConferencia, numSala, horario[horarioOPC], aforoConferencia));
        }





    }
}