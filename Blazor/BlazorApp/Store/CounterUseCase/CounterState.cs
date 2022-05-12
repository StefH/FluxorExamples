using Fluxor;

namespace BlazorApp.Store.CounterUseCase;

// State should be decorated with [FeatureState] for automatic discovery when services.AddFluxor is called.
[FeatureState]
public record CounterState
{
	public int ClickCount { get; }

	// A parameterless constructor is required on state for determining the initial state, and can be private or public.
	private CounterState() : this(1)
	{
	}

	public CounterState(int clickCount)
	{
		ClickCount = clickCount;
	}
}