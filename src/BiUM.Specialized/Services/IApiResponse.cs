using BiUM.Specialized.Common.Enums;
using BiUM.Specialized.Common.ViewModels;

namespace BiUM.Specialized.Services;

public interface IApiResponse
{
    void AddMessage(ResponseMessage message);
    void AddMessage(IReadOnlyList<ResponseMessage> messages);
    void AddMessage(string errorCode, string errorMessage, MessageSeverity? severity);
    void AddMessage(string apiName, string errorCode, string errorMessage, bool friendly, MessageSeverity severity);
}