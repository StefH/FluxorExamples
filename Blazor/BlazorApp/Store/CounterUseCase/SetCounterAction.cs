namespace BlazorApp.Store.CounterUseCase;

public class SetCounterAction
{
	public int ClickCount { get; }

	public SetCounterAction(int clickCount)
	{
		ClickCount = clickCount;
	}
}