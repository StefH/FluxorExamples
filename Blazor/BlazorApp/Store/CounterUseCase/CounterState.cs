using Fluxor;

namespace BlazorApp.Store.CounterUseCase;

// State should be decorated with [FeatureState] for automatic discovery when services.AddFluxor is called.
[FeatureState]
public record CounterState(int ClickCount)
{
	// A parameterless constructor is required on state for determining the initial state, and can be private or public.
	private CounterState() : this(1)
	{
	}
}