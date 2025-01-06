using System;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace Instead_PowerShell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(args[0]);
            try
            {
                using (PowerShell powerShell = PowerShell.Create())
                {
                    powerShell.AddScript("Invoke-Expression " + args[0]);

                    Collection<PSObject> results = powerShell.Invoke();

                    foreach (PSObject result in results)
                    {
                        Console.WriteLine(result.ToString());
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invoke needs param");
                Console.ResetColor();
            }
        }
    }
}
