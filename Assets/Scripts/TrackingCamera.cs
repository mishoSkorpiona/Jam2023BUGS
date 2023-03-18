using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    public List<Rigidbody2D> bodies;
    public float followStrength = 1;
    public float followSpeed = 0.9f;
    public float bigFollowDistance = 0.3f;
    Plane playingPlane = new Plane(Vector3.forward, Vector3.zero);

    float lerpAmount;

    void Update()
    {
        Vector2 targetPosition = AverageVector(bodies.Select(x => GetBodyPosition(x)));

        playingPlane.Raycast(new Ray(transform.position, transform.forward), out float enter);
        Vector3 currentFacingPosition = transform.position + enter * transform.forward;

        float diff = targetPosition.x - currentFacingPosition.x;

        if (Mathf.Abs(diff) > bigFollowDistance)
            lerpAmount += followSpeed * Time.deltaTime;
        else
            lerpAmount -= followSpeed * Time.deltaTime;

        //lerpAmount = lerpAmount;

        float rotationThisFrame = diff * lerpAmount * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationThisFrame);
    }

    Vector2 GetBodyPosition(Rigidbody2D body)
    {
        return body.position + body.velocity * followStrength;
    }

    Vector2 AverageVector(IEnumerable<Vector2> vectors)
    {
        Vector2 sum = Vector2.zero;

        foreach (var v in vectors)
            sum += v;

        sum /= vectors.Count();

        return sum;
    }
}
