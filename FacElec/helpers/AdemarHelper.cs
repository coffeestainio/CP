using System;
using System.Diagnostics;

namespace FacElec.helpers
{
    public static class AdemarHelper
    {
        static public void callBatchProcess (string claveFactura){
            try
            {
                var batCommand = $"DFD {claveFactura} -Q -M D";
                //var batCommand = "C:\\facelecCP\\bat.bat";

                Console.WriteLine($"Ejecutando comando: {batCommand}");

                var proc = new Process();
                proc.StartInfo.FileName = "C:\\DSign\\ExeFirmaFactura\\FacturaElectronicaCR_CS.exe";
                proc.StartInfo.Arguments = batCommand;
                proc.Start();

            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
    }
}
