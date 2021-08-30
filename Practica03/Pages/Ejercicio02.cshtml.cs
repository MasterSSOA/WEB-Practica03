using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practica03.Pages
{
    public class Ejercicio02Model : PageModel
    {
        //Propiedades.
        public int monto { get; set; }
        public bool isABCBank { get; set; }
        public string title1 { get; set; }
        public string title2 { get; set; }
        public string detail1 { get; set; }
        public string detail2 { get; set; }
        public string detail3 { get; set; }

        public int _milDisponible;
        private int _cienDisponible;
        private int _quinientosDisponible;

        //Funciones.
        public void Dispensar(bool isABCBank, int monto) 
        {
            int milDispensado = 0;
            int cienDispensado = 0;
            int quinientosDispensado = 0;
            int limiteDispensar;

            if (monto != 0)
            {
                //Validación de Banco.
                if (isABCBank)
                    limiteDispensar = 10000;
                else
                    limiteDispensar = 2000;

                //Dispensación de Billetes.
                if (monto % 100 != 0)
                {
                    this.title1 = "El monto no puede ser dispensado.";
                }
                else
                {
                    if (monto > limiteDispensar)
                    {
                        this.title1 = "Ha excedido el límite por transacción.";
                    }
                    else
                    {
                        while (monto >= 1000)
                        {
                            _milDisponible -= 1;
                            milDispensado += 1;
                            monto -= 1000;
                        }
                        while (monto >= 500)
                        {
                            _quinientosDisponible -= 1;
                            quinientosDispensado += 1;
                            monto -= 500;
                        }
                        while (monto >= 100)
                        {
                            _cienDisponible -= 1;
                            cienDispensado += 1;
                            monto -= 100;
                        }

                        //Asignación de Variables.
                        this.title1 = "Retire su dinero";
                        this.title2 = "Billetes Dispensados";
                        this.detail1 = "1,000 x " + milDispensado + "";
                        this.detail2 = "  500 x " + quinientosDispensado + "";
                        this.detail3 = "  100 x " + cienDispensado + "";
                    }
                }
            }
            else
            {
                //Asignación de Variables.
                this.title1 = "";
                this.title2 = "";
                this.detail1 = "";
                this.detail2 = "";
                this.detail3 = "";
            }
        }

        public void OnGet(bool isABCBank, int monto)
        {
            Dispensar(isABCBank, monto);
        }
    }
}
