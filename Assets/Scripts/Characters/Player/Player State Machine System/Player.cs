using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 状态变量
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerWallClimbState WallClimbState { get; private set; }
    public PlayerWallGrabState WallGrabState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerLedgeClimbState LedgeClimbState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerAttackState PrimaryAttackState { get; private set; }
    public PlayerAttackState SecondAttackState { get; private set; }

    [SerializeField]
    private PlayerData data;
    #endregion

    #region 组件
    public Core core { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public PlayerInventory inventory { get; private set; }
    #endregion

    #region 其他变量

    private Vector2 velocityWorkSpace;  //中间值

    public Transform DashDirectionIndicator;
    #endregion

    #region 回调函数
    private void Awake()
    {
        core = GetComponentInChildren<Core>();
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, data, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, data, "move");
        JumpState = new PlayerJumpState(this, StateMachine, data, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, data, "inAir");
        LandState = new PlayerLandState(this, StateMachine, data, "land");
        WallClimbState = new PlayerWallClimbState(this, StateMachine, data, "wallClimb");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, data, "wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, data, "wallGrab");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, data, "wallJump");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, data, "ledgeClimbState"); 
        DashState = new PlayerDashState(this, StateMachine, data, "dash");
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, data, "attack");
        SecondAttackState = new PlayerAttackState(this, StateMachine, data, "attack");
    }
    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        DashDirectionIndicator = transform.Find("DashDirectionIndicator");
        inventory = GetComponent<PlayerInventory>();

        StateMachine.Initialize(IdleState); //初始化为idle状态

        PrimaryAttackState.SetWeapon(inventory.weapons[(int)CombatInputs.primary]);
        //SecondAttackState.SetWeapon(inventory.weapons[(int)CombatInputs.primary]);
    }
    private void Update()
    {
        core.LogicUpdate();
        StateMachine.CurrentState.LogicalUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Check Functions
    
    #endregion

    #region Other Function
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    #endregion
}
