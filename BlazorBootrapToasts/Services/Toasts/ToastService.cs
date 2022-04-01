using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using BlazorBootrapToasts.Brokers.DateTimes;
using BlazorBootrapToasts.Models.Toasts;

namespace BlazorBootrapToasts.Services.Toasts;

public class ToastService : IDisposable, IToastService
{
    public ToastService(IDateTimeBroker dateTimeBroker)
    {
        timer = new(1000);
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
        this.dateTimeBroker = dateTimeBroker;
        toasts = new List<ToastModel>();
    }

    public event EventHandler TimerSyncEvent;
    public event EventHandler ToastListEvent;

    public void AddToast(ToastModel toast)
    {
        if (!toasts.Any(a => a.Id == toast.Id))
        {
            toast.Created = dateTimeBroker.GetDateTime();
            toasts.Add(toast);
            ToastListEvent?.Invoke(this, new EventArgs());
        }
    }

    public void RemoveToast(Guid guid)
    {
        var toast = toasts.FirstOrDefault(a => a.Id == guid);
        if (toast is not null)
        {
            toasts.Remove(toast);
            ToastListEvent?.Invoke(this, new EventArgs());
        }
    }

    public void Dispose()
    {
        if (timer is not null)
        {
            timer.Stop();
            timer.Dispose();
        }
    }

    public ICollection<ToastModel> Toasts => toasts;

    internal IDateTimeBroker DateTimeBroker => dateTimeBroker;

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        => TimerSyncEvent?.Invoke(this, e);
    private readonly Timer timer;
    private readonly IDateTimeBroker dateTimeBroker;
    private readonly List<ToastModel> toasts;
}
