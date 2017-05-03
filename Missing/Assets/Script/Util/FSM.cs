using System;
using System.Collections.Generic;
using System.Diagnostics;

public class FSM<TContext> {
	private readonly TContext _context;
	private readonly Dictionary<Type, State> _stateCache = new Dictionary<Type, State>();
	public State CurrentState{get; private set;}

	private State _PendingState;
	public FSM(TContext context){
		_context = context;
	}
	public void Update(){
		PerformPendingTransition();
		Debug.Assert(CurrentState != null);
		CurrentState.Update();
		PerformPendingTransition();
	}
	public void TransitionTo<TState>() where TState: State{
		_PendingState = GetOrCreateState<TState>();
	}
	private void PerformPendingTransition(){
		if(_PendingState != null){
			if(CurrentState != null)
				CurrentState.OnExit();
			CurrentState = _PendingState;
			CurrentState.OnEnter();
			_PendingState = null;
		}
	}
	private TState GetOrCreateState<TState>() where TState: State{
		State state;
		if(_stateCache.TryGetValue(typeof(TState), out state)){
			return state as TState;
		}
		else{
			var newState = Activator.CreateInstance<TState>();
			newState.parent = this;
			newState.Init();
			_stateCache[typeof(TState)] = newState;
			return newState;
		}
	}
	public void Clear(){
		foreach(var state in _stateCache.Values){
			state.CleanUp();
		}
		_stateCache.Clear();
	}
	public bool IF_IN_THIS_STATE<TState>() where TState: State{
		if(_stateCache.ContainsKey(typeof(TState)))
			return typeof(TState) == CurrentState.GetType();
		else
			return false;
	}

	public abstract class State{
		internal FSM<TContext> parent {get; set;}
		protected TContext Context{get{return parent._context;}}
		protected void TransitionTo<TState>() where TState: State{
			parent.TransitionTo<TState>();
		}
        public virtual void Init() {}
        public virtual void OnEnter() {}
        public virtual void OnExit() {}
        public virtual void Update() {}
        public virtual void CleanUp() {}
	}
}

