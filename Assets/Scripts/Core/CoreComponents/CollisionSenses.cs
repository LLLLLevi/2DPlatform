using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于检测碰撞关系
/// </summary>
public class CollisionSenses : CoreComponent
{
    #region Check Transform
    public Transform GroundCheckTrans { get => GenericNotImplementedError<Transform>.TryGet
            (groundCheckTrans, core.transform.parent.name);
        set => groundCheckTrans = value; }
    public Transform WallCheckTrans
    {
        get => GenericNotImplementedError<Transform>.TryGet
            (wallCheckTrans, core.transform.parent.name);
        set => wallCheckTrans = value; }
    public Transform LedgeCheckTrans
    {
        get => GenericNotImplementedError<Transform>.TryGet
            (ledgeCheckTrans, core.transform.parent.name);
        set => ledgeCheckTrans = value; }

    public float GroundCheckRidius { get => groundCheckRidius; set => groundCheckRidius = value; }
    public float WallCheckDistence { get => wallCheckDistence; set => wallCheckDistence = value; }
    public float LedgeCheckDistence { get => ledgeCheckDistence; set => ledgeCheckDistence = value; }
    public LayerMask WhatIsGround { get => whatIsGround; set => whatIsGround = value; }

    [SerializeField] private Transform groundCheckTrans;
    [SerializeField] private Transform wallCheckTrans;
    [SerializeField] private Transform ledgeCheckTrans;

    [SerializeField] private float groundCheckRidius;
    [SerializeField] private float wallCheckDistence;
    [SerializeField] private float ledgeCheckDistence;

    [SerializeField] private LayerMask whatIsGround;
    #endregion

    #region Check Functions
    public bool Ground
    {
        get => Physics2D.OverlapCircle(groundCheckTrans.position,
            groundCheckRidius, whatIsGround);
    }

    public bool WallFront
    {
        get => Physics2D.Raycast(wallCheckTrans.position,
            Vector2.right * core.Movement.FacingDirection, wallCheckDistence, whatIsGround);
    }
    public bool WallBack
    {
        get => Physics2D.Raycast(wallCheckTrans.position,
            Vector2.right * -core.Movement.FacingDirection, wallCheckDistence, whatIsGround);
    }
    public bool Ledge
    {
        get => Physics2D.Raycast(ledgeCheckTrans.position,
            Vector2.right * core.Movement.FacingDirection, wallCheckDistence, whatIsGround);
    }
    public bool Ledge_Down
    {
        get => Physics2D.Raycast(ledgeCheckTrans.position,
            Vector2.down, ledgeCheckDistence, whatIsGround);
    }
    #endregion
}
