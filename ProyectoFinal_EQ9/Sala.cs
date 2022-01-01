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

        public string getNombreSala()
        {
            return this.nombreSala;
        }

        public void setNombreSala(string nombreSala)
        {
            this.nombreSala = nombreSala;
        }

        public int getAforo()
        {
            return this.aforo;
        }

        public void setAforo(int aforo)
        {
            this.aforo = aforo;
        }



    }
}