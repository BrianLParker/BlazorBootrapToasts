using BlazorBootrapToasts.Models.Toasts;
using BlazorBootrapToasts.Services.Toasts;
using Microsoft.AspNetCore.Components;

namespace BlazorBootrapToasts.Views.Components.Toasts;

public class Toast : ComponentBase
{
    private ToastModel toast;

    [Inject]
    IToastService Service { get; set; }

    [Parameter]
    public RenderFragment Content { get; set; }

    [Parameter]
    public RenderFragment Heading { get; set; }

    [Parameter]
    public RenderFragment Icon { get; set; }

    [Parameter]
    public string ImageUrl { get; set; }

    [Parameter]
    public string HeadingMarkup { get; set; }

    [Parameter]
    public string ContentMarkup { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    protected override void OnInitialized()
    {
        toast = new ToastModel
        {
            Content = ChildContent == null ? Content : ChildContent,
            ContentMarkup = ContentMarkup,
            Icon = Icon,
            ImageUrl = ImageUrl,
            Heading = Heading,
            HeadingMarkup = HeadingMarkup
        };

        Service.AddToast(toast);
        base.OnInitialized();
    }

    protected override bool ShouldRender()
    {
        var should = base.ShouldRender();
        if (should) toast.NotifyWatchers();
        return should;
    }
}
