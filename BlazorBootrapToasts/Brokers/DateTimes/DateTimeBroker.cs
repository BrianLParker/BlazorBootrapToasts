using System;

namespace BlazorBootrapToasts.Brokers.DateTimes;

public class DateTimeBroker : IDateTimeBroker
{
    public DateTimeOffset GetDateTime() => DateTimeOffset.Now;
}
