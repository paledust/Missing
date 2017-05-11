using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC_FSM_Head : Human_Head {
	[SerializeField] protected InteObject_Handler objectHandler;//Object Handler Can arrange mutilple object and find the important one for NPC to look at
	protected FSM<NPC_FSM_Head> fsm;
	protected GameObject Looker;
	public bool IF_ENGAGING{get{return fsm.IF_IN_THIS_STATE<ENGAGING_State>();}}
	public int CurrentPriority{get{return objectHandler.CurrentPriority;}}
	public InterestingObject CurrentObject {get{return objectHandler.CurrentObject;}}
	protected bool IF_BEING_LOOKED;

	protected override void Start(){
		objectHandler = new InteObject_Handler(gameObject);
		objectHandler.Start();

		Service.eventManager.RegisterHandler<Fall_Event>(ENGAGE_SHORT_EVENT<Fall_Event>);
		Service.eventManager.RegisterHandler<Long_Range_Event>(ENGAGE_LONG_EVENT<Long_Range_Event>);

		tempRotation = transform.rotation;
		base.Start();
		fsm = new FSM<NPC_FSM_Head>(this);
		fsm.TransitionTo<PENDING_State>();
	}
	protected override void Update(){
		base.Update();
		fsm.Update();
		if(CurrentObject != null){
			LookTo(CurrentObject.transform.position);
		}
		objectHandler.Update();
	}

	protected virtual void PENDING_Update(){}
	protected virtual void ENGAGING_Update(){}
	protected virtual void STARING_Update(){
		if(Looker != null){
			LookTo(Looker.transform.position);
		}
	}

	//FSM STATE
	public class NPC_State: FSM<NPC_FSM_Head>.State{		
		protected float timer = 0.0f;
		protected float ExitTime = 2.0f;
	}
	public class PENDING_State: NPC_State{
		protected float LookTimer = 0.0f;
		protected float RandomTimer;
		protected Vector3 RandomLook_Dir;
		public override void Init(){
			LookTimer = 0.0f;
			RandomTimer = 0.0f;
			ExitTime = 2.0f;
			RandomLook_Dir = Context.transform.parent.rotation * Context.RandomLookPoint() + Context.transform.position;
		}
		public override void OnEnter(){
			LookTimer = 0.0f;
			RandomLook_Dir = Context.transform.parent.rotation * Context.RandomLookPoint() + Context.transform.position;
		}
		public override void Update(){
			Context.PENDING_Update();
			Context.LookTo(RandomLook_Dir);
			RandomTimer += Time.deltaTime;
			if(RandomTimer >= Random.Range(2.0f,100.0f)){
				RandomLook_Dir = (Context.transform.parent.rotation * Context.RandomLookPoint() + Context.transform.position);
				RandomTimer = 0.0f;
			}

			if(Context.CurrentObject){
				TransitionTo<ENGAGING_State>();
			}

			if(Context.IF_BEING_LOOKED){
				LookTimer += Time.deltaTime;
			}
			else if(LookTimer != 0.0f){
				LookTimer = 0.0f;
			}

			if(LookTimer >= 2.0f){
				TransitionTo<STARING_State>();
			}
		}
	}
	public class ENGAGING_State: NPC_State{
		InterestingObject pendingObject;
		public override void Init(){
		}
		public override void OnEnter(){
		}
		public override void Update(){
			Context.ENGAGING_Update();
			if(Context.CurrentObject == null){
				TransitionTo<PENDING_State>();
			}
			else{
				Context.LookTo(Context.CurrentObject.transform.position);
			}
		}
	}
	public class STARING_State: NPC_State{
		public override void Init(){
			timer = 0.0f;
			ExitTime = 1.0f;
		}
		public override void OnEnter(){
			timer = 0.0f;
		}
		public override void Update(){
			Context.STARING_Update();
			if(Context.Looker != null){
				timer = 0.0f;
			}
			else{
				timer += Time.deltaTime;
				if(timer >= ExitTime){
					TransitionTo<PENDING_State>();
				}
			}

			if(Context.CurrentObject){
				TransitionTo<ENGAGING_State>();
			}
		}
	}
	protected void ENGAGE_SHORT_EVENT<TEvent>(Event e) where TEvent: Short_Range_Event{
		TEvent tempEvent = e as TEvent;

		if((transform.position - tempEvent.context.transform.position).magnitude <= tempEvent.AffectRange){
			if(tempEvent.priority > CurrentPriority){
				objectHandler.Get_Short(tempEvent.context.GetComponent<InterestingObject>());
			}
		}
	}
	protected void ENGAGE_LONG_EVENT<TEvent>(Event e) where TEvent: Long_Range_Event{
		TEvent tempEvent = e as TEvent;
		objectHandler.Add_Long(tempEvent.context.GetComponent<InterestingObject>());
	}
	public void BE_LOOKED(bool if_Look,GameObject _Looker, float _Engage_Enter_Time = 2.0f){
		IF_BEING_LOOKED = if_Look;
		Looker = _Looker;
	}
}
