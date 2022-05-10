﻿using Fluxor;

namespace StateActionsReducers.Store.CounterUseCase;

[FeatureState]
public class CounterState
{
	public int ClickCount { get; }

	public CounterState() { }
	public CounterState(int clickCount)
	{
		ClickCount = clickCount;
	}
}