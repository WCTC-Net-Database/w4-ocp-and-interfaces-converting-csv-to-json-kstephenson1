namespace w4_assignment_ksteph.UI;
public class MainMenuItem : MenuItem
{
    // The MainMenuItem is used to store information about the selection in the main menu.  This stores the index, name (from the base),
    // description, and an acion in a handy object that can be referenced easily later.
    public int Index { get; set; }
    public string Description { get; set; }
    public Action Action { get; set; }

    public MainMenuItem(int index, string name, string desc, Action action): base(name)
    {
        Index = index;
        Name = name;
        Description = desc;
        Action = action;
    }
}
