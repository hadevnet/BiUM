using BiUM.Specialized.Common.Enums;

namespace BiUM.Specialized.Common.Models;

public class ResponseMessage
{
    public string ApiName { get; set; } = string.Empty;
    public string ErrorCode { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public string? Exception { get; set; }
    public bool Friendly { get; set; }
    public MessageSeverity Severity { get; set; }
}