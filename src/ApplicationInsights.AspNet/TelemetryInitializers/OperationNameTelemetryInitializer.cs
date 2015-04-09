﻿namespace Microsoft.ApplicationInsights.AspNet.TelemetryInitializers
{
    using System;
    using Microsoft.ApplicationInsights.Channel;
    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.AspNet.Http;
    using Microsoft.AspNet.Hosting;

    public class OperationNameTelemetryInitializer : TelemetryInitializerBase
    {
        public OperationNameTelemetryInitializer(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        { }

        protected override void OnInitializeTelemetry(HttpContext platformContext, RequestTelemetry requestTelemetry, ITelemetry telemetry)
        {
            if (string.IsNullOrEmpty(telemetry.Context.Operation.Name))
            {
                var name = platformContext.Request.Method + " " + platformContext.Request.Path.Value; // Test potential dangerous request;
                
                var telemetryType = telemetry as RequestTelemetry;
                if (telemetryType != null && string.IsNullOrEmpty(telemetryType.Name))
                {
                    telemetryType.Name = name;
                }

                telemetry.Context.Operation.Name = name;
            }
        }
    }
}