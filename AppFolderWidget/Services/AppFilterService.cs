using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFolderWidget.Services
{
    public class AppFilterService
    {
        private static readonly string[] ExcludedPrefixes =
        {
            // Desinstaladores
            "Uninstall",
            "Desinstalar",
            // "Update X" — actualizadores
            "Update",        
            "Actualizar",
            // Reparadores
            "Repair",         
            "Reparar",
            // Modificadores de instalación
            "Modify",         
            "Modificar",
            // Licencias y readmes (nunca son apps)
            "Readme",
            "Léame",
            "Leame",
            "License",
            "Licencia",
        };

        public bool ShouldInclude(string appName)
        {
            if (string.IsNullOrWhiteSpace(appName))
                return false;

            foreach (var prefix in ExcludedPrefixes)
            {
                if (appName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            return true;
        }
    }
}
