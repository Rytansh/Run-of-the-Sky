using UnityEngine;

public class CollisionDetector
{
    private float objectHeight;
    private float objectWidth;


    public CollisionDetector(float objectHeight, float objectWidth)
    {
        this.objectHeight = objectHeight;
        this.objectWidth = objectWidth;
    }

    public bool IsGrounded(Vector2 position, float groundCheckDistance, LayerMask groundMask)
    {

        float bottomY = position.y - (objectHeight / 2f);

        Vector2 rayOriginBack = new Vector2(position.x - (objectWidth / 2f), bottomY);
        Vector2 rayOriginFront = new Vector2(position.x + (objectWidth / 2f), bottomY);

        RaycastHit2D hitBack = Physics2D.Raycast(rayOriginBack, Vector2.down, groundCheckDistance, groundMask);
        RaycastHit2D hitFront = Physics2D.Raycast(rayOriginFront, Vector2.down, groundCheckDistance, groundMask);

        return hitBack.collider != null || hitFront.collider != null;
    }

    public bool IsCollidingSideways(Vector2 position, float groundCheckDistance, LayerMask groundMask)
    {
        float halfHeight = objectHeight * 0.5f;
        float rightX = position.x + (objectWidth / 2f);

        Vector2 rayOriginBottom = new Vector2(rightX, position.y - (objectHeight / 2f));
        Vector2 rayOriginMid = new Vector2(rightX, position.y - (objectHeight / 2f) + halfHeight);
        Vector2 rayOriginTop = new Vector2(rightX, position.y + (objectHeight / 2f));

        RaycastHit2D hitBottom = Physics2D.Raycast(rayOriginBottom, Vector2.right, groundCheckDistance, groundMask);
        RaycastHit2D hitMid = Physics2D.Raycast(rayOriginMid, Vector2.right, groundCheckDistance, groundMask);
        RaycastHit2D hitTop = Physics2D.Raycast(rayOriginTop, Vector2.right, groundCheckDistance, groundMask);

        return hitBottom.collider != null || hitMid.collider != null || hitTop.collider != null;
    }

    public bool IsCollidingUpwards(Vector2 position, float groundCheckDistance, LayerMask groundMask)
    {

        float topY = position.y + (objectHeight / 2f);

        Vector2 rayOriginBack = new Vector2(position.x - (objectWidth / 2f), topY);
        Vector2 rayOriginFront= new Vector2(position.x + (objectWidth / 2f), topY);

        RaycastHit2D hitBack = Physics2D.Raycast(rayOriginBack, Vector2.up, groundCheckDistance, groundMask);
        RaycastHit2D hitFront = Physics2D.Raycast(rayOriginFront, Vector2.up, groundCheckDistance, groundMask);

        return hitBack.collider != null || hitFront.collider != null;
    }

}
