﻿using Common.Exceptions;
using System.Collections.Concurrent;

namespace RestaurantManagement.Middlewares;

public class RateLimitMiddleware(RequestDelegate next, int requestLimit, TimeSpan timeSpan, IHttpContextAccessor contextAccessor)
{
    private readonly RequestDelegate _next = next;
    private readonly int _requestLimit = requestLimit;
    private readonly TimeSpan _timeSpan = timeSpan;
    private readonly IHttpContextAccessor _contextAccessor = contextAccessor;

    private readonly ConcurrentDictionary<string, List<DateTime>> _requiredTimes = new();

    public async Task InvokeAsync(HttpContext context)
    {

        var isAuthenticated = _contextAccessor.HttpContext!.User.Identity!.IsAuthenticated;

        var ep = context.GetEndpoint()?.DisplayName;
        var now = DateTime.UtcNow;
        var requestLog = _requiredTimes.GetOrAdd(ep, []);
        lock (requestLog)
        {
            requestLog.RemoveAll(timeStamp => timeStamp <= now - _timeSpan);
            if (requestLog.Count >= _requestLimit)
            {
                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                context.Response.Headers.RetryAfter = _timeSpan.TotalMinutes.ToString();
                throw new ToManyRequestException("To many Requests");
            }
            requestLog.Add(now);
        }
        await _next(context);
    }



}
