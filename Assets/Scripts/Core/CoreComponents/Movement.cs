using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    private Vector2 workSpace;
    public Rigidbody2D RB { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    public bool canSetVelocity;     //是否能设置速度

    protected override void Awake()
    {
        base.Awake();

        RB = GetComponentInParent<Rigidbody2D>();
        FacingDirection = 1;

        canSetVelocity = true;
    }

    public void LogicUpdate()
    {
        CurrentVelocity = RB.velocity;
    }

    #region Set Functions
    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
        SetFinalVelocity();
    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        workSpace = direction * velocity;
        SetFinalVelocity();
    }

    public void SetVelocityX(float velocityX)
    {
        workSpace.Set(velocityX, CurrentVelocity.y);
        SetFinalVelocity();
    }
    public void SetVelocityY(float velocityY)
    {
        workSpace.Set(CurrentVelocity.x, velocityY);
        SetFinalVelocity();
    }
    public void SetVelocityZero()
    {
        workSpace = Vector2.zero;
        SetFinalVelocity();
    }

    public void SetFinalVelocity()
    {
        if (canSetVelocity)
        {
            RB.velocity = workSpace;
            CurrentVelocity = workSpace;
        }
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)    //有输入且与当前方向相反
        {
            Flip();
        }
    }

    public void Flip()
    {
        FacingDirection *= -1;
        RB.transform.Rotate(0.0f, 180f, 0.0f);
    }

    #endregion
}
