using UnityEngine;

public class NPC_FSM_Head : Human_Head {
	protected FSM<NPC_FSM_Head> fsm;
	protected GameObject ENGAGING_Object;
	private bool _IF_SEEN = false;
	public bool IF_SEEN{get{return _IF_SEEN;}}
	protected override void Start(){
		tempRotation = transform.rotation;
		_IF_SEEN = false;
		base.Start();
		fsm = new FSM<NPC_FSM_Head>(this);
		fsm.TransitionTo<PENDING_State>();
	}
	protected override void Update(){
		base.Update();

		fsm.Update();
	}
	public void SET_SEEN(bool _if_Seen, GameObject _Engaging_Object){_IF_SEEN = _if_Seen; ENGAGING_Object = _Engaging_Object;}
	//FSM STATE
	public class NPC_State: FSM<NPC_FSM_Head>.State{}
	public class PENDING_State: NPC_State{
		private float timer = 0.0f;
		private float ExitTime = 2.0f;
		public override void Init(){
			timer = 0.0f;
			ExitTime = 2.0f;
		}
		public override void Update(){
			Debug.Log("In PENDING STATE");
			Context.LookTo(Context.transform.parent.rotation * Context.RandomLookPoint() + Context.transform.position);
			if(Context._IF_SEEN){
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
		public override void Update(){
			Debug.Log("In ENGAGING STATE");
			Context.LookTo(Context.ENGAGING_Object.transform.position);
			if(!Context._IF_SEEN){
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
}
