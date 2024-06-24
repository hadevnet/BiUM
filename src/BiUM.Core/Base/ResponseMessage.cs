namespace BiUM.Core.Base;

public class ResponseMessage
{
    public string ApiName { get; set; } = string.Empty;
    public string ErrorCode { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public string? Exception { get; set; }
    public bool Friendly { get; set; }
    public bool Critical { get; set; } = false;
    public MessageSeverity Severity { get; set; }
}