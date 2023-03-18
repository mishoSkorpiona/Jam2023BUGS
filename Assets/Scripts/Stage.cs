using UnityEngine;

public class Stage : MonoBehaviour
{
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
        newPlayer.SetUpUI();

        characterCount++;
    }
}
