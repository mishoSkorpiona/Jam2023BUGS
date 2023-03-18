using UnityEngine;

public class BouncyPlayerFlinger : MonoBehaviour
{
    public float flingStrength = 2f;
    public Vector2 flingDir;


    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        if (rb) rb.velocity = flingDir.normalized * flingStrength;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + flingStrength * new Vector3(flingDir.x, flingDir.y).normalized);
    }
}
