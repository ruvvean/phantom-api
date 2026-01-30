using Phantom.Api.Interfaces;

namespace Phantom.Api.Settings;

public class StandaloneAppSettings : IAppSettings
{
    public string? EndpointDirectory { get; set; }

    string IAppSettings.EndpointDirectory => string.IsNullOrWhiteSpace(this.EndpointDirectory) ? AppContext.BaseDirectory : this.EndpointDirectory;
}
