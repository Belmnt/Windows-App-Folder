using AppFolderWidget.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFolderWidget.Services
{
    public class LaunchService
    {
        public void Launch(AppItem app)
        {
            if (string.IsNullOrWhiteSpace(app.LaunchTarget))
                throw new InvalidOperationException("La app no tiene destino de lanzamiento válido");

            Process.Start(new ProcessStartInfo
            {
                FileName = app.LaunchTarget,
                UseShellExecute = true
            });
        }
    }
}
