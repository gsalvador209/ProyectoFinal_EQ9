using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoPOO
{
    public class Ponente
    {
        private String nombrePonente;
        private String nombreConferencia;
        private String tiempoConferencia; // horas o minutos
        private int numeroSala; // número de la sala de la conferencia
        private int aforoConferencia; // número de personas que fueren asistir a la conferencia.

        private String horarioConferencia;

        public Ponente(String nombrePonente, String nombreConferencia, String tiempoConferencia, int numeroSala, String horario, int aforoConferencia)
        {
            this.nombrePonente = nombrePonente;
            this.nombreConferencia = nombreConferencia;
            this.tiempoConferencia = tiempoConferencia;
            this.numeroSala = numeroSala;
            this.horarioConferencia = horario;
            this.aforoConferencia = aforoConferencia;
        }
        public String getTiempoConferencia()
        {
            return this.tiempoConferencia;
        }

        public int getNumeroSala()
        {
            return this.numeroSala;
        }

        public int getAforoConferencia()
        {
            return this.aforoConferencia;
        }
        public String getNombrePonente()
        {
            return this.nombrePonente;
        }


        public String getNombreConferencia()
        {
            return this.nombreConferencia;
        }

        public String toString()
        {
            return "\n" + "Nombre Ponente: " + this.nombrePonente + "\n" +
                   "Nombre Conferencia: " + this.nombreConferencia + "\n" +
                   "Tiempo de Conferencia: " + this.tiempoConferencia + "\n" +
                   "Numero de Sala: " + this.numeroSala + "\n" +
                   "Aforo: " + this.aforoConferencia + "\n" +
                   "Horario: " + this.horarioConferencia + "\n";
        }
    }
}