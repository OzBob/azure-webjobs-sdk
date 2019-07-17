// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Scale
{
    internal class TriggerScaleMonitorProvider : ITriggerScaleMonitorProvider
    {
        private readonly List<ITriggerScaleMonitor> _monitors = new List<ITriggerScaleMonitor>();

        public void Register(ITriggerScaleMonitor provider)
        {
            // TODO: need concurrency controll here - multiple threads can be accessing this collection
            // e.g. startup thread registering providers, while GetScaleStatus calls might be reading
            // monitors
            _monitors.Add(provider);
        }
        
        public IEnumerable<ITriggerScaleMonitor> GetMonitors()
        {
            return _monitors.AsReadOnly();
        }
    }
}
