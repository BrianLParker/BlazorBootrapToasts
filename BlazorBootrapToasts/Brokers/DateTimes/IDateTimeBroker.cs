using System;

namespace BlazorBootrapToasts.Brokers.DateTimes;

public interface IDateTimeBroker
{
    DateTimeOffset GetDateTime();
}
