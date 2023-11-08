using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockbackable
{
    void Knocback(Vector2 angle, float strength, int direction);
}
