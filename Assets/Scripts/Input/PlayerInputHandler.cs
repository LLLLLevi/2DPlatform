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

    //��ȡ+1��-1   �ڵ����ϸ��ܲ����� ����ҡ�˵��豸�ͺ���Ҫ
    public int NormInputX { get; private set; } 
    public int NormInputY { get; private set; } 
    public bool IfJumpInput { get; private set; }
    public bool IfJumpInputStop { get; private set; }
    public bool IfDashInput { get; private set; }
    public bool IfDashInputStop { get; private set; }
    public bool IfGrabInput { get; private set; }
    public bool[]  AttackInputs { get; private set; }   //ͬʱ������������Ҽ�����

    bool isOpen = false;
    [SerializeField] GameObject bag;

    [SerializeField]
    private float inputHoldTime = 0.3f;

    private float jumpInputStartTime;
    private float dashInputStartTime;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        int count = Enum.GetValues(typeof(CombatInputs)).Length;    //��ȡ��������ö�ٵ�Ԫ�ظ���
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
        //������Ծ��
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
        //������Ծ��
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

    //��������
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

    //��ȡ��̷���
    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {
        RawDashDirectionInput = context.ReadValue<Vector2>();

        //��������Ļ����ת��Ϊ����������ȥ��ҵ�ǰ������ǳ�̷���
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
            isOpen = !isOpen;   //����ֵ
            bag.SetActive(isOpen);
        }

    }
}

public enum CombatInputs
{
    primary,
    secondary
}
