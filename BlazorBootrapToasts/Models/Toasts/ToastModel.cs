using System;
using Microsoft.AspNetCore.Components;

namespace BlazorBootrapToasts.Models.Toasts;

public class ToastModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public RenderFragment Content { get; set; }
    public RenderFragment Heading { get; set; }
    public RenderFragment Icon { get; set; }
    public string ImageUrl { get; set; }
    public string HeadingMarkup { get; set; }
    public string ContentMarkup { get; set; }
    public DateTimeOffset Created { get; set; }
    internal void NotifyWatchers() => ContentUpdated?.Invoke(this, new EventArgs());
    internal event EventHandler ContentUpdated;
}
