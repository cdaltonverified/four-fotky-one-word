using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Position
{
    Left, Right, Up, Down
}
public class ChangePosition : MonoBehaviour
{
    public Position Pos;
    private void OnEnable()
    {
        switch (Pos)
        {
            case Position.Left:
                Vector2 p = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.5f));
                p.x -= GetComponent<BoxCollider2D>().size.x;
                transform.position = p;
                break;
            case Position.Right:
                Vector2 pp = Camera.main.ViewportToWorldPoint(new Vector2(1, 0.5f));
                pp.x += GetComponent<BoxCollider2D>().size.x;
                transform.position = pp;
                break;
            case Position.Up:
                Vector2 ppp = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 1));
                ppp.y += GetComponent<BoxCollider2D>().size.y;
                transform.position = ppp;
                break;
            case Position.Down:
                Vector2 pppp = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0));
                pppp.y -= GetComponent<BoxCollider2D>().size.y;
                transform.position = pppp;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
