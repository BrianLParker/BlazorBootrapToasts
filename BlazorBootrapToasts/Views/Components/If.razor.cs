using Microsoft.AspNetCore.Components;

namespace BlazorBootrapToasts.Views.Components;

public partial class If : ComponentBase
{
    [Parameter]
    public bool Condition { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public RenderFragment IfTrue { get; set; }

    [Parameter]
    public RenderFragment IfFalse { get; set; }
}
