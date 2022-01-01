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

        public String getTiempoConferencia()
        {
            return this.tiempoConferencia;
        }

        public void setTiempoConferencia(String tiempoConferencia)
        {
            this.tiempoConferencia = tiempoConferencia;
        }

        public int getNumeroSala()
        {
            return this.numeroSala;
        }

        public void setNumeroSala(int numeroSala)
        {
            this.numeroSala = numeroSala;
        }

        public int getAforoConferencia()
        {
            return this.aforoConferencia;
        }

        public void setAforoConferencia(int aforoConferencia)
        {
            this.aforoConferencia = aforoConferencia;
        }



        public String getNombrePonente()
        {
            return this.nombrePonente;
        }

        public void setNombrePonente(String nombrePonente)
        {
            this.nombrePonente = nombrePonente;
        }

        public String getNombreConferencia()
        {
            return this.nombreConferencia;
        }

        public void setNombreConferencia(String nombreConferencia)
        {
            this.nombreConferencia = nombreConferencia;
        }

    }
}