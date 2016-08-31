using System.ComponentModel;

namespace CP.WinFormsUI.Docking
{
	public abstract class ThemeBase : Component, ITheme
	{
	    public abstract void Apply(DockPanel dockPanel);
	}
}
