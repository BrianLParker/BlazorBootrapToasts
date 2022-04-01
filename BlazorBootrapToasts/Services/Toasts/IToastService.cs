using System;
using System.Collections.Generic;
using BlazorBootrapToasts.Models.Toasts;

namespace BlazorBootrapToasts.Services.Toasts
{
    public interface IToastService
    {
        ICollection<ToastModel> Toasts { get; }

        event EventHandler TimerSyncEvent;
        event EventHandler ToastListEvent;

        void AddToast(ToastModel toast);
        void Dispose();
        void RemoveToast(Guid guid);
    }
}