using UnityEngine;

public class BouncyPlayerFlinger : MonoBehaviour
{
    public float flingStrength = 2f;
    public Vector3 flingDir;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb) rb.velocity += flingDir.normalized * flingStrength;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + flingStrength * flingDir.normalized);
    }
}
