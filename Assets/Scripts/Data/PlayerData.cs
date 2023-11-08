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
    public float variableJumpHeightMultiplier = 0.5f;   //一半的跳跃高度

    [Header("wall slide state")]
    public float wallSlideVelocity = 3f;

    [Header("wall climb state")]
    public float wallClimbVelocity = 3f;

    [Header("ledge climb state")]
    public Vector2 startOffset;
    public Vector2 stopOffset;

    [Header("dash state")]
    public float dashCoolDown = 0.5f;       //冲刺冷却时间
    public float maxHoldTime = 1f;          //慢动作持续时间
    public float holdTimeScale = 0.25f;     //时间放慢至四分之一   
    public float dashTime = 0.2f;           //向前冲刺时间
    public float dashVelocity = 30f;
    public float drag = 10f;    //空气阻力
    public float dashEndYMultipliter = 0.2f;        //冲刺高度倍数
    public float distBetweenAfterImages = 0.5f;     

}
