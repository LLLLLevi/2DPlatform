using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;

    public Vector2 RawMoveInput { get; private set; } 
    public Vector2 RawDashDirectionInput { get; private set; }
    public Vector2Int DashDirectionInput { get; private set; }

    //获取+1和-1   在电脑上感受不出来 在有摇杆的设备就很需要
    public int NormInputX { get; private set; } 
    public int NormInputY { get; private set; } 
    public bool IfJumpInput { get; private set; }
    public bool IfJumpInputStop { get; private set; }
    public bool IfDashInput { get; private set; }
    public bool IfDashInputStop { get; private set; }
    public bool IfGrabInput { get; private set; }
    public bool[]  AttackInputs { get; private set; }   //同时存左键攻击和右键攻击

    bool isOpen = false;
    [SerializeField] GameObject bag;

    [SerializeField]
    private float inputHoldTime = 0.3f;

    private float jumpInputStartTime;
    private float dashInputStartTime;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        int count = Enum.GetValues(typeof(CombatInputs)).Length;    //获取攻击输入枚举的元素个数
        AttackInputs = new bool[count];

        cam = Camera.main;
    }
    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMoveInput = context.ReadValue<Vector2>();

        NormInputX = Mathf.RoundToInt(RawMoveInput.x);
        NormInputY = Mathf.RoundToInt(RawMoveInput.y); 
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        //按下跳跃键
        if (context.started)
        {
            IfJumpInput = true;
            IfJumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            IfJumpInputStop = true;
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IfGrabInput = true;
        }

        if (context.canceled)
        {
            IfGrabInput = false;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        //按下跳跃键
        if (context.started)
        {
            IfDashInput = true;
            IfDashInputStop = false;
            dashInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            IfDashInputStop = true;
        }
    }

    //攻击输入
    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.primary] = true;
        }
        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.primary] = false;
        }
    }
    public void OnSecondAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }
        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }

    //获取冲刺方向
    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {
        RawDashDirectionInput = context.ReadValue<Vector2>();

        //将鼠标从屏幕坐标转换为世界坐标后减去玩家当前坐标便是冲刺方向
        RawDashDirectionInput = cam.ScreenToWorldPoint
            ((Vector3)RawDashDirectionInput) - transform.position;

        DashDirectionInput = Vector2Int.RoundToInt(RawDashDirectionInput.normalized);
    }

    public void IfUseJumpInput() => IfJumpInput = false;
    public void IfUseDashInput() => IfDashInput = false;

    private void CheckJumpInputHoldTime()
    {
        if(Time.time > jumpInputStartTime + inputHoldTime)
        {
            IfJumpInput = false;
        }
    }
    private void CheckDashInputHoldTime()
    {
        if (Time.time > dashInputStartTime + inputHoldTime)
        {
            IfDashInput = false;
        }
    }

    public void OpenBag(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isOpen = !isOpen;   //赋反值
            bag.SetActive(isOpen);
        }

    }
}

public enum CombatInputs
{
    primary,
    secondary
}
