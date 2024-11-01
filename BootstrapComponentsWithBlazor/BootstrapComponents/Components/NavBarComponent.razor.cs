namespace BootstrapComponents.Components;

public partial class NavBarComponent
{
    public string ContentId { get; set; } = Guid.NewGuid().ToString();
    [Parameter] public string? Background { get; set; }
    [Parameter] public RenderFragment? BrandContent { get; set; }
    [Parameter] public string BrandLink { get; set; } = "/";

    [Parameter] public List<Link> Links { get; set; } = new();

    [Parameter] public List<Dropdown> Dropdowns { get; set; } = new();
    [Parameter] public RenderFragment? ExtraContent { get; set; }


}