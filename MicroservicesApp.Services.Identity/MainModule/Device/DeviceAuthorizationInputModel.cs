// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using MicroservicesApp.Services.Identity.MainModule.Consent;

namespace MicroservicesApp.Services.Identity.MainModule.Device
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}