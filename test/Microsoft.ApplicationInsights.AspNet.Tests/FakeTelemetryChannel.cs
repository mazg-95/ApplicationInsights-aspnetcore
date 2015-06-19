﻿namespace Microsoft.ApplicationInsights.AspNet.Tests
{
    using System;
    using Microsoft.ApplicationInsights.Channel;

    // TODO: Remove FakeTelemetryChannel when we can use a dynamic test isolation framework, like NSubstitute or Moq
    internal class FakeTelemetryChannel : ITelemetryChannel
    {
        public Action<ITelemetry> OnSend = t => { };

        public string EndpointAddress
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool? DeveloperMode { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }

        public void Send(ITelemetry item)
        {
            this.OnSend(item);
        }
    }
}