using System;
using BlazorBootrapToasts.Services.Toasts;
using Microsoft.AspNetCore.Components;

namespace BlazorBootrapToasts.Views.Components.Toasts;

public partial class ToastAnchor : ComponentBase
{
    [Inject]
    IToastService Service { get; set; }

    protected override void OnInitialized()
    {
        Service.ToastListEvent += ToastListChanged;
        base.OnInitialized();
    }

    private void ToastListChanged(object sender, EventArgs e) => InvokeAsync(StateHasChanged);
}
