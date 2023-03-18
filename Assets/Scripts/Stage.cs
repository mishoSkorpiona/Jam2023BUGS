using UnityEngine;

public class Stage : MonoBehaviour
{
    public Color gizmoColour;
    public bool showZZero;

    public TrackingCamera trackingCamera;

    public Transform[] spawnPositions;
    int characterCount;

    public void SpawnCharacters(params CharacterStats[] stats)
    {
        foreach (var character in stats)
            SpawnCharacter(character);
    }

    public void SpawnCharacter(CharacterStats stats)
    {
        GameObject newCharacter = Instantiate(stats.characterPrefab);
        newCharacter.transform.position = spawnPositions[characterCount].position;

        Player newPlayer = newCharacter.GetComponentInChildren<Player>();
        newPlayer.playerID = characterCount;

        trackingCamera.bodies.Add(newPlayer.myRigidbody);

        characterCount++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColour;
        if (showZZero) Gizmos.DrawCube(Vector3.zero, new Vector3(100, 100, 0));
    }
}
