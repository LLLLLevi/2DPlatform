using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("move state")]
    public float movementVelocity = 10f;

    [Header("jump state")]
    public float jumpVelocity = 15f;
    public int acountOfJumps = 1;

    [Header("wall jump state")]
    public float wallJumpVelocity = 20f;
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);

    [Header("in air state")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;   //һ�����Ծ�߶�

    [Header("wall slide state")]
    public float wallSlideVelocity = 3f;

    [Header("wall climb state")]
    public float wallClimbVelocity = 3f;

    [Header("ledge climb state")]
    public Vector2 startOffset;
    public Vector2 stopOffset;

    [Header("dash state")]
    public float dashCoolDown = 0.5f;       //�����ȴʱ��
    public float maxHoldTime = 1f;          //����������ʱ��
    public float holdTimeScale = 0.25f;     //ʱ��������ķ�֮һ   
    public float dashTime = 0.2f;           //��ǰ���ʱ��
    public float dashVelocity = 30f;
    public float drag = 10f;    //��������
    public float dashEndYMultipliter = 0.2f;        //��̸߶ȱ���
    public float distBetweenAfterImages = 0.5f;     

}
