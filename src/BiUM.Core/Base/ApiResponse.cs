namespace BiUM.Core.Base;

public class ApiResponse<T> : IApiResponse
{
    public T? Value { get; set; }

    public virtual bool Success
    {
        get
        {
            var suc = from s in _messages
                      where s.Severity == MessageSeverity.Error
                      select s;

            return !suc.Any();
        }
    }

    private readonly List<ResponseMessage> _messages = [];

    public IReadOnlyList<ResponseMessage> Messages => _messages;

    public void AddMessage(ResponseMessage message)
    {
        _messages.Add(message);
    }

    public void AddMessage(IReadOnlyList<ResponseMessage> messages)
    {
        _messages.AddRange(messages);
    }

    public void AddMessage(string apiName, string errorCode, string errorMessage, bool friendly, bool critical, MessageSeverity severity)
    {
        _messages.Add(new ResponseMessage
        {
            ApiName = apiName,
            ErrorCode = errorCode,
            ErrorMessage = errorMessage,
            Friendly = friendly,
            Critical = critical,
            Severity = severity
        });
    }
}