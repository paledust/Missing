using UnityEngine;

public class NPC_FSM_Head : Human_Head {
	protected FSM<NPC_FSM_Head> fsm;
	protected GameObject ENGAGING_Object;
	private bool _IF_ENGAGIN = false;
	private float ENGAGE_ENTER_TIME;
	public bool IF_ENGAGING{get{return _IF_ENGAGIN;}}
	public int CurrentPriority = -1;
	protected override void Start(){
		Service.eventManager.RegisterHandler<Fall_Event>(ENGAGE_EVENT<Fall_Event>);
		Service.eventManager.RegisterHandler<Shift_Event>(ENGAGE_EVENT<Shift_Event>);

		CurrentPriority = -1;
		tempRotation = transform.rotation;
		_IF_ENGAGIN = false;
		base.Start();
		fsm = new FSM<NPC_FSM_Head>(this);
		fsm.TransitionTo<PENDING_State>();
	}
	protected override void Update(){
		base.Update();
		fsm.Update();
	}
	public void SET_ENGAGING(bool _if_Engaging, GameObject _Engaging_Object, float _Engage_Enter_Time = 0.0f){
		_IF_ENGAGIN = _if_Engaging;
		ENGAGING_Object = _Engaging_Object;
		ENGAGE_ENTER_TIME = _Engage_Enter_Time;
	}
	//FSM STATE
	public class NPC_State: FSM<NPC_FSM_Head>.State{}
	public class PENDING_State: NPC_State{
		private float timer = 0.0f;
		private float ExitTime = 2.0f;
		public override void Init(){
			timer = 0.0f;
			ExitTime = 2.0f;
		}
		public override void OnEnter(){
			timer = 0.0f;
			ExitTime = Context.ENGAGE_ENTER_TIME;
		}
		public override void Update(){
			Context.LookTo(Context.transform.parent.rotation * Context.RandomLookPoint() + Context.transform.position);
			if(Context._IF_ENGAGIN){
				timer += Time.deltaTime;
				if(timer >= ExitTime){
					TransitionTo<ENGAGING_State>();
				}
			}
			else{
				if(timer != 0.0f){
					timer = 0.0f;
				}
			}
		}
	}
	public class ENGAGING_State: NPC_State{
		private float timer = 0.0f;
		private float ExitTime = 2.0f;
		public override void Init(){
			timer = 0.0f;
		}
		public override void OnEnter(){
			timer = 0.0f;
		}
		public override void Update(){
			Context.LookTo(Context.ENGAGING_Object.transform.position);
			if(!Context._IF_ENGAGIN){
				timer += Time.deltaTime;
				if(timer >= ExitTime){
					TransitionTo<PENDING_State>();
				}
			}
			else{
				if(timer != 0.0f){
					timer = 0.0f;
				}
			}
		}
	}

	protected void ENGAGE_EVENT<TEvent>(Event e) where TEvent: Att_Event{
		TEvent tempEvent = e as TEvent;
		Debug.Log(tempEvent.ToString());
		if((transform.position - tempEvent.context.transform.position).magnitude <= tempEvent.AffectRange){
			if(tempEvent.priority > CurrentPriority){
				CurrentPriority = tempEvent.priority;
				SET_ENGAGING(true, tempEvent.context);
			}
		}
		else{
			
		}
	}
}
