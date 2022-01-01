using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoPOO
{
    public class Horario
    {
        private int IdHorario;
        private string nombreSala;
        private string horario;
        private string empresaSala; // Nombre que aparto la sala
        private string nombreConferencia;


        // Métodos Getters y Setters
        public int getIdHorario()
        {
            return this.IdHorario;
        }

        public void setIdHorario(int IdHorario)
        {
            this.IdHorario = IdHorario;
        }

        public string getNombreSala()
        {
            return this.nombreSala;
        }

        public void setNombreSala(string nombreSala)
        {
            this.nombreSala = nombreSala;
        }

        public string getHorario()
        {
            return this.horario;
        }

        public void setHorario(string horario)
        {
            this.horario = horario;
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




    }
}