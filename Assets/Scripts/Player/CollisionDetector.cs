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
        float quarterWidth = objectWidth * 0.25f;
        float threeQuarterWidth = objectWidth * 0.75f;

        float bottomY = position.y - (objectHeight / 2f);

        Vector2 rayOriginQuarter = new Vector2(position.x - (objectWidth / 2f) + quarterWidth, bottomY);
        Vector2 rayOriginThreeQuarter = new Vector2(position.x - (objectWidth / 2f) + threeQuarterWidth, bottomY);

        RaycastHit2D hitQuarter = Physics2D.Raycast(rayOriginQuarter, Vector2.down, groundCheckDistance, groundMask);
        RaycastHit2D hitThreeQuarter = Physics2D.Raycast(rayOriginThreeQuarter, Vector2.down, groundCheckDistance, groundMask);

        Debug.DrawRay(rayOriginQuarter, Vector2.down * groundCheckDistance, hitQuarter ? Color.green : Color.red);
        Debug.DrawRay(rayOriginThreeQuarter, Vector2.down * groundCheckDistance, hitThreeQuarter ? Color.green : Color.red);

        return hitQuarter.collider != null || hitThreeQuarter.collider != null;
    }

    public bool IsCollidingSideways(Vector2 position, float groundCheckDistance, LayerMask groundMask)
    {
        float quarterHeight = objectHeight * 0.25f;
        float threeQuarterHeight = objectHeight * 0.75f;

        float rightX = position.x + (objectWidth / 2f);

        Vector2 rayOriginBottom = new Vector2(rightX, position.y - (objectHeight / 2f) + quarterHeight);
        Vector2 rayOriginTop = new Vector2(rightX, position.y - (objectHeight / 2f) + threeQuarterHeight);

        RaycastHit2D hitBottom = Physics2D.Raycast(rayOriginBottom, Vector2.right, groundCheckDistance, groundMask);
        RaycastHit2D hitTop = Physics2D.Raycast(rayOriginTop, Vector2.right, groundCheckDistance, groundMask);

        Debug.DrawRay(rayOriginBottom, Vector2.right * groundCheckDistance, hitBottom ? Color.green : Color.red);
        Debug.DrawRay(rayOriginTop, Vector2.right * groundCheckDistance, hitTop ? Color.green : Color.red);

        return hitBottom.collider != null || hitTop.collider != null;
    }

    public bool IsCollidingUpwards(Vector2 position, float groundCheckDistance, LayerMask groundMask)
    {
        float quarterWidth = objectWidth * 0.25f;
        float threeQuarterWidth = objectWidth * 0.75f;

        float topY = position.y + (objectHeight / 2f);

        Vector2 rayOriginQuarter = new Vector2(position.x - (objectWidth / 2f) + quarterWidth, topY);
        Vector2 rayOriginThreeQuarter = new Vector2(position.x - (objectWidth / 2f) + threeQuarterWidth, topY);

        RaycastHit2D hitQuarter = Physics2D.Raycast(rayOriginQuarter, Vector2.up, groundCheckDistance, groundMask);
        RaycastHit2D hitThreeQuarter = Physics2D.Raycast(rayOriginThreeQuarter, Vector2.up, groundCheckDistance, groundMask);

        Debug.DrawRay(rayOriginQuarter, Vector2.up * groundCheckDistance, hitQuarter ? Color.green : Color.red);
        Debug.DrawRay(rayOriginThreeQuarter, Vector2.up * groundCheckDistance, hitThreeQuarter ? Color.green : Color.red);

        return hitQuarter.collider != null || hitThreeQuarter.collider != null;
    }

}
