using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderData : MonoBehaviour
{
    [Range(0.0f, 360f)]
    public float knockbackDirection = 90;

    [Range(0.0f, 10f)]
    public float knockbackPower = 4;

    [Range(0.0f, 1f)]
    public float damagePercentage = 0.8f;

    [Range(0.0f, 1.2f)]
    public float stunDuration = 0.4f;

    void OnDrawGizmos()
    {
        // Draw a gizmo to show the direction and power of the knockback
        Vector2 directionVector = Quaternion.Euler(0, 0, knockbackDirection) * Vector2.up;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)directionVector * knockbackPower);
        Gizmos.DrawWireSphere(transform.position, GetComponent<CircleCollider2D>().radius);
    }
}