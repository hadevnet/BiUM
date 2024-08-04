using BiUM.Specialized.Common.Enums;
using BiUM.Specialized.Common.Models;
using BiUM.Specialized.Services;
using Microsoft.EntityFrameworkCore;

namespace BiUM.Specialized.Common.API;

public class ApiEmptyResponse : IApiResponse
{
    public virtual bool Success
    {
        get
        {
            var success = from s in _messages
                      where s.Severity == MessageSeverity.Error
                      select s;

            return !success.Any();
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

    public void AddMessage(string errorMessage, MessageSeverity? severity)
    {
        _messages.Add(new ResponseMessage
        {
            ApiName = "",
            ErrorCode = "",
            ErrorMessage = errorMessage,
            Friendly = false,
            Severity = severity ?? MessageSeverity.Error
        });
    }

    public void AddMessage(string errorCode, string errorMessage, MessageSeverity? severity)
    {
        _messages.Add(new ResponseMessage
        {
            ApiName = "",
            ErrorCode = errorCode,
            ErrorMessage = errorMessage,
            Friendly = false,
            Severity = severity ?? MessageSeverity.Error
        });
    }

    public void AddMessage(string apiName, string errorCode, string errorMessage, bool friendly, MessageSeverity severity)
    {
        _messages.Add(new ResponseMessage
        {
            ApiName = apiName,
            ErrorCode = errorCode,
            ErrorMessage = errorMessage,
            Friendly = friendly,
            Severity = severity
        });
    }
}

public class ApiResponse<T> : ApiEmptyResponse
{
    public T? Value { get; set; }
}

public class PaginatedApiResponse<T> : ApiResponse<List<T>>
{
    public int PageNumber { get; }

    public int TotalPages { get; }

    public int TotalCount { get; }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;

    public PaginatedApiResponse()
    {
        PageNumber = 1;
        TotalPages = 1;
        TotalCount = 0;
        Value = [];
    }

    public PaginatedApiResponse(List<T> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling((double)count / (double)pageSize);
        TotalCount = count;
        Value = items;
    }
}