using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu()]
public class CharacterStats : ScriptableObject
{
    public GameObject characterPrefab;
    public GameObject playerUIPrefab;
    public GameObject inputModule;
    public float maxHealth;
    public int amountOfJumps = 1;
}
