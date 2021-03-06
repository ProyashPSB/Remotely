﻿using Microsoft.Extensions.DependencyInjection;
using Remotely.Desktop.Core;
using Remotely.Desktop.Core.Interfaces;
using Remotely.Desktop.Core.Services;
using Remotely.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Remotely.Desktop.Win.Services
{
    public class ShutdownServiceWin : IShutdownService
    {
        public async Task Shutdown()
        {
            Logger.Debug($"Exiting process ID {Process.GetCurrentProcess().Id}.");
            var casterSocket = ServiceContainer.Instance.GetRequiredService<CasterSocket>();
            await casterSocket.DisconnectAllViewers();
            System.Windows.Forms.Application.Exit();
            App.Current.Shutdown();
            Environment.Exit(0);
        }
    }
}
