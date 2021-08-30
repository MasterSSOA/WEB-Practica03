using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practica03.Pages
{
    public class Ejercicio01Model : PageModel
    {
        //Propiedades.
        public double monto { get; set; }
        public double cuotas { get; set; }
        public double interesAnual { get; set; }

        //Funciones.
        public double CalcularCuota() 
        {
            // _____________________________________
            //|                Leyenda              |
            //|_____________________________________|
            //| cantidad   = Número de Cuotas.      |
            //| interesAnual  = Interés Anual.      |
            //| monto = Monto Principal (Préstamo). |
            //|_____________________________________|
            //

            double Cuota;
            double monto;
            double cantidad;
            double interesAnual;
            double ParteArriba;
            double ParteAbajo;

            monto = this.monto;
            cantidad = this.cuotas;
            interesAnual = (this.interesAnual / 100) / 12;

            ParteArriba = monto * interesAnual;
            ParteAbajo = 1 - (Math.Pow((1 + interesAnual), -cantidad));
            Cuota = ParteArriba / ParteAbajo;

            return Cuota;
        }
        public void OnGet(double monto, double cuotas, double interesAnual)
        {
            this.monto = monto;
            this.cuotas = cuotas;
            this.interesAnual = interesAnual;
        }
    }
}
