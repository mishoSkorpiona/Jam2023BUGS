using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stage : MonoBehaviour
{
    public Color gizmoColour;
    public bool showZZero;

    public TrackingCamera trackingCamera;

    public Transform[] spawnPositions;
    int characterCount;

    private void Start()
    {
        FightData data = FindObjectOfType<FightData>();
        if (data)
            SpawnCharacters(data.players);
    }

    public void SpawnCharacters(List<CharacterStats> stats)
    {
        foreach (var character in stats)
            SpawnCharacter(character);
    }

    public void SpawnCharacter(CharacterStats stats)
    {
        GameObject newCharacter = Instantiate(stats.characterPrefab, stats.inputModule.transform);
        newCharacter.transform.position = spawnPositions[characterCount].position;

        Player newPlayer = newCharacter.GetComponentInChildren<Player>();
        newPlayer.playerID = characterCount;

        if (trackingCamera) trackingCamera.bodies.Add(newPlayer.myRigidbody);

        characterCount++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColour;
        if (showZZero) Gizmos.DrawCube(Vector3.zero, new Vector3(100, 100, 0));
    }
}
