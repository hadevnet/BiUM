namespace BiUM.Core.Base;

public interface IApiResponse
{
    void AddMessage(ResponseMessage message);
    void AddMessage(IReadOnlyList<ResponseMessage> messages);
    void AddMessage(string apiName, string errorCode, string errorMessage, bool friendly, bool critical, MessageSeverity severity);
}