using System;
using FacElec.helpers;
using FacElec.sync;

namespace FacElec
{
    class Program
    {
        static void Main(string[] args)
        {
            Sincronizador.SincronizarFacturas();
            //RestHelper.DoSomething();
        }
    }
}
