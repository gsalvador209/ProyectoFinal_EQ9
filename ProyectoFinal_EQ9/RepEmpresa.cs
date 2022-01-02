using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoPOO
{
    class RepEmpresa
    {
        //****ATRIBUTOS******
        public string nombre;
        public string email;
        public string celular;

        //***CONSTRUCTOR****
        public RepEmpresa()
        {

        }

        //****MÉTODOS****

        private string Solicitar(string indicación)
        {
            Usuario us = new Usuario();
            return us.Solicitar(indicación);
        }
        public void SetNombre()
        {
            this.nombre = Solicitar(" Ingrese el nombre del representante: ");
        }

        public void SetCelular()
        {
            this.celular = Solicitar(" Ingrese el teléfono celular: ");
        }

        public void SetEmail()
        {
            this.email = Solicitar(" Ingrese el email: ");
        }

        public string GetNombre()
        {
            return nombre;
        }

        public string GetCelular()
        {
            return celular;
        }

        public string GetEmail()
        {
            return email;
        }


    }
}
