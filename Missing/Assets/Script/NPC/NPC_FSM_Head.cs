using UnityEngine;

public class NPC_FSM_Head : Human_Head {
	[SerializeField] int Sensibility = -10;
	protected FSM<NPC_FSM_Head> fsm;
	protected GameObject ENGAGING_Object;
	protected GameObject Looker;
	public bool IF_ENGAGING{get{return fsm.IF_IN_THIS_STATE<ENGAGING_State>();}}
	public int CurrentPriority = -1;
	protected int PendingPriority = -1;
	protected bool IF_BEING_LOOKED;

	protected override void Start(){
		Service.eventManager.RegisterHandler<Fall_Event>(ENGAGE_EVENT<Fall_Event>);
		// Service.eventManager.RegisterHandler<Shift_Event>(ENGAGE_EVENT<Shift_Event>);

		CurrentPriority = Sensibility;
		PendingPriority = CurrentPriority;

		tempRotation = transform.rotation;
		base.Start();
		fsm = new FSM<NPC_FSM_Head>(this);
		fsm.TransitionTo<PENDING_State>();
	}
	protected override void Update(){
		base.Update();
		fsm.Update();
	}
	protected void SET_ENGAGING(bool _if_Aware, GameObject _Engaging_Object){
		ENGAGING_Object = _Engaging_Object;
		fsm.TransitionTo<ENGAGING_State>();
	}
	//FSM STATE
	public class NPC_State: FSM<NPC_FSM_Head>.State{		
		protected float timer = 0.0f;
		protected float ExitTime = 2.0f;
	}
	public class PENDING_State: NPC_State{
		protected float LookTimer = 0.0f;
		protected float RandomTimer;
		public override void Init(){
			LookTimer = 0.0f;
			RandomTimer = 0.0f;
			ExitTime = 2.0f;
		}
		public override void OnEnter(){
			Context.CurrentPriority = Context.Sensibility;
			LookTimer = 0.0f;
		}
		public override void Update(){
			RandomTimer += Time.deltaTime;
			if(RandomTimer >= Random.Range(2.0f,100.0f)){
				Context.LookTo(Context.transform.parent.rotation * Context.RandomLookPoint() + Context.transform.position);
				RandomTimer = 0.0f;
			}
			if(Context.IF_BEING_LOOKED){
				LookTimer += Time.deltaTime;
			}

			if(LookTimer >= 2.0f){
				Context.CurrentPriority = -9;
				Context.SET_ENGAGING(true, Context.Looker);
			}
		}
	}
	public class REACT_State: NPC_State{
		public override void Init(){
			timer = 0.0f;
		}
		public override void OnEnter(){
			timer = 0.0f;
		}
		public override void Update(){
			timer += Time.deltaTime;
		}
	}
	public class ENGAGING_State: NPC_State{
		public override void Init(){
			timer = 0.0f;
		}
		public override void OnEnter(){
			timer = 0.0f;
		}
		public override void Update(){
			Debug.Assert(Context.ENGAGING_Object);
			Context.LookTo(Context.ENGAGING_Object.transform.position);

			timer += Time.deltaTime;
			if(timer >= ExitTime){
				Context.SET_ENGAGING(false, null);
				TransitionTo<PENDING_State>();
			}
		}
	}

	protected void ENGAGE_EVENT<TEvent>(Event e) where TEvent: Att_Event{
		TEvent tempEvent = e as TEvent;
		if((transform.position - tempEvent.context.transform.position).magnitude <= tempEvent.AffectRange){
			if(tempEvent.priority > CurrentPriority){
				CurrentPriority = tempEvent.priority;
				SET_ENGAGING(true, tempEvent.context);
			}
		}
	}
	public void BE_LOOKED(bool if_Look,GameObject _Looker, float _Engage_Enter_Time = 2.0f){
		IF_BEING_LOOKED = if_Look;
		Looker = _Looker;
	}
}
