using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoPOO
{
    public class Sala
    {
        private string nombreSala; // Nombre de la sala
        private int aforo; // Aqui hay que definirlo y cuando se agregue el aforo para la conferencia, checar si está en el rango de aforo de la sala.

        string[] horario = new string[6];

        public Sala(int aforo,string nombreSala){
            this.aforo = aforo;
            this.nombreSala = nombreSala;
            switch (nombreSala)
            {
                case "Sala 2":
                    string[] horarioSala = new string[]{"x","x"," ","x","x"," "};
                    this.horario = horarioSala;
                    break;
                case "Sala 3":
                    string[] horarioSala2 = new string[]{"x","x","x"," ","x"," "};
                    this.horario = horarioSala2;
                    break;
                case "Sala 4":
                    string[] horarioSala3 = new string[]{" ","x"," ","x","x","x"};
                    this.horario = horarioSala3;
                    break;

                default:
                    string[] horarioSala4 = new string[]{"x","x","x","x","x","x"};
                    this.horario = horarioSala4;
                    break;
            }
        }
        public void salasDisponibles(int index,int i)
        {
            if (horario[index - 1].CompareTo("x") != 0)
            {
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("(" + i + ")");
                Console.ResetColor();
                Console.WriteLine(" " + nombreSala + "\n");
            }
        }
        public Boolean setHorario(int index){
            Boolean swap = true;
            if(horario[index]=="x"){
                Console.WriteLine("Introduce un horario que no este ocupado");
            }
            else{
                swap = false;
                horario[index]="x";
            }
            return swap;
        }
        public string getNombreSala()
        {
            return this.nombreSala;
        }

        public int getAforo()
        {
            return this.aforo;
        }

        public string getValidacion(){
            return "     " + horario[0] + "    \t\t" + horario[1] + "    \t\t   " + horario[2] + "  \t\t    " + horario[3] + " \t\t     " + horario[4] + " \t\t      " + horario[5] + "\n";
        }



    }
}