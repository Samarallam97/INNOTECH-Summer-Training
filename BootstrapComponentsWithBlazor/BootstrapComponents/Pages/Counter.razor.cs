namespace BootstrapComponents.Pages;

public partial class Counter
{

    //////////// Dropdown compnent used in navbar

    public static List<Link> DropdownLinks_1 = new List<Link>
{
    new Link { Text = "Home  1", Url = "/" },
    new Link { Text = "Counter  1", Url = "/counter" },
    new Link { Text = "Weather  1", Url = "/weather" }
};

    public static List<Link> DropdownLinks_2 = new List<Link>
{
    new Link { Text = "Home  2", Url = "/" },
    new Link { Text = "Counter  2", Url = "/counter" },
    new Link { Text = "Weather  2", Url = "/weather" }
};

    public static List<Link> DropdownLinks_3 = new List<Link>
{
    new Link { Text = "Home  3", Url = "/" },
    new Link { Text = "Counter  3", Url = "/counter" },
    new Link { Text = "Weather  3", Url = "/weather" }
};

    public List<Dropdown> Dropdowns = new List<Dropdown>
{
    new Dropdown { Title = "First Dropdown " , Links = DropdownLinks_1 , Background = "btn-danger"} ,
    new Dropdown { Title = "Second Dropdown " , Links = DropdownLinks_2 , Background = "btn-danger"} ,
    new Dropdown { Title = "Third Dropdown " , Links = DropdownLinks_3 , Background = "btn-danger"} ,
};

    //////////// Dropdown component alone

    public List<Link> Options1 = new List<Link>
{
    new Link { Text = "Home", Url ="/" },
    new Link { Text = "Counter", Url = "/counter"},
    new Link { Text = "Weather", Url = "/weather" }
};


    public List<Link> Options2 = new List<Link>
{
    new Link { Text = "Picture 1", Url ="https://picsum.photos/id/237/200/300" },
    new Link { Text = "Picture 2", Url = "https://picsum.photos/id/27/200/300"},
    new Link { Text = "Picture 3", Url = "https://picsum.photos/id/7/200/300" }
};





}