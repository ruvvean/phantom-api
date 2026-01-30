using Phantom.Api.Interfaces;

namespace Phantom.Api.Settings;

public class DockerAppSettings : IAppSettings
{
    public string? EndpointDirectory { get; set; }

    string IAppSettings.EndpointDirectory => string.IsNullOrWhiteSpace(this.EndpointDirectory) ? "/data" : this.EndpointDirectory;
}
