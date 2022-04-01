using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace BlazorBootrapToasts.Views.Components;

public partial class For<TItem> : ComponentBase
{
    [Parameter]
    public ICollection<TItem> Items { get; set; }

    [Parameter]
    public RenderFragment<TItem> ChildContent { get; set; }

    [Parameter]
    public bool Virtualize {  get; set; } = true;
}
