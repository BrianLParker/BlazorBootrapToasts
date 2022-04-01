using System;
using BlazorBootrapToasts.Brokers.DateTimes;
using BlazorBootrapToasts.Models.Toasts;
using BlazorBootrapToasts.Services.Toasts;
using Microsoft.AspNetCore.Components;

namespace BlazorBootrapToasts.Views.Components.Toasts;

public partial class ToastDisplay : ComponentBase, IDisposable
{
    [Inject]
    IToastService Service { get; set; }

    [Inject]
    IDateTimeBroker DateTimeBroker { get; set; }

    [Parameter]
    public ToastModel Toast { get; set; }

    protected override void OnInitialized()
    {
        Service.TimerSyncEvent += SyncEvent;
        Toast.ContentUpdated += SyncEvent;
        base.OnInitialized();
    }

    void SyncEvent(object sender, EventArgs e)
    {
        var now = DateTimeBroker.GetDateTime();
        statusMessage = GetMessage(now - Toast.Created);
        InvokeAsync(StateHasChanged);
    }

    void RemoveMe() => Service.RemoveToast(Toast.Id);

    string statusMessage;

    public void Dispose()
    {
        Toast.ContentUpdated += SyncEvent;
        Service.TimerSyncEvent -= SyncEvent;
    }

    string GetMessage(TimeSpan duration)
    {
        if (duration.TotalHours >= 1)
        {
            if (duration.Hours == 1)
            {
                return $"{duration.Hours} hour ago";
            }
            return $"{duration.Hours} hours ago";
        }
        if (duration.TotalMinutes >= 1)
        {
            if (duration.Minutes == 1)
            {
                return $"{duration.Minutes} minute ago";
            }
            return $"{duration.Minutes} minutes ago";
        }
        if (duration.TotalSeconds >= 5)
        {
            return $"{duration.Seconds} seconds ago";
        }
        else
        {
            return "just now";
        }
    }
}
