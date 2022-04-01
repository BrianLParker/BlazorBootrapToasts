using Microsoft.AspNetCore.Components;

namespace BlazorBootrapToasts.Views.Components;

public partial class If : ComponentBase
{
    private RenderFragment TrueFragment =>
        IsTrueFragmentEmpty && IsFalseFragmentEmpty ? ChildContent : IfTrue;
    private bool IsTrueFragmentEmpty => IfTrue == default;
    private bool IsFalseFragmentEmpty => IfFalse == default;
}
