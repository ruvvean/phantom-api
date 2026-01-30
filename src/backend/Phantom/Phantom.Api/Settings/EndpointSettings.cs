namespace Phantom.Api.Settings;

public class EndpointSettings
{
    public uint Delay { get; set; } = 0;
    public uint ResponseCode { get; set; } = 200;
    public uint ResponseCodeError { get; set; } = 500;

    public string? RequestBody { get; set; }
    public string? ResponseBody { get; set; }
    public string? ResponseBodyError { get; set; }
}
