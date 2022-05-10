namespace BlazorApp.Store;

public class SetCounterAction
{
	public int ClickCount { get; }

	public SetCounterAction(int clickCount)
	{
		ClickCount = clickCount;
	}
}