using System.Diagnostics;

namespace FacElec.helpers
{
    public static class AdemarHelper
    {
        static public void callBatchProcess (string claveFactura){
            //var batCommand = $"C:\\DSign\\ExeFirmaFactura\\FacturaElectronicaCR_CS.exe DFD {claveFactura} -Q  -M D";
            var batCommand = "C:\\facelecCP\\bat.bat";

            //Process proc = Process.Start(batCommand);
        }
    }
}
