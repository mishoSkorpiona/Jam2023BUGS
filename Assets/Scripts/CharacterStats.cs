using UnityEngine;

[CreateAssetMenu()]
public class CharacterStats : ScriptableObject
{
    public GameObject characterPrefab;
    public GameObject playerUIPrefab;
    public float maxHealth;
    public int amountOfJumps = 1;
}
