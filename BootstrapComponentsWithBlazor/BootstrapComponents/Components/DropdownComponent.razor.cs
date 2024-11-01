namespace BootstrapComponents.Components;

public partial class DropdownComponent
{

    [Parameter] public string Title { get; set; }

    [Parameter] public string Background { get; set; }

    [Parameter] public string Mode { get; set; }

    [Parameter] public string Direction { get; set; }

    [Parameter] public List<Link> Options { get; set; } = new List<Link>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
            await jSRuntime.InvokeVoidAsync("DropDown", null);
    }

}