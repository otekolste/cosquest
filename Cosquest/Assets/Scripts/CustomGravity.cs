using UnityEngine;
using System.Collections.Generic;

public static class CustomGravity
{
   public static Vector2 getGravity(Vector2 pos, out Vector2 upAxis)
    {
        upAxis = pos.normalized;
        return upAxis * Physics2D.gravity.y;
    }
    public static Vector2 getGravity(Vector2 pos)
    {
        return pos.normalized * Physics2D.gravity.y;
    }
    public static Vector2 getUpAxis(Vector2 pos)
    {
        return pos.normalized;
    }
}