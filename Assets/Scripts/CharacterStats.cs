using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu()]
public class CharacterStats : ScriptableObject
{
    public GameObject characterPrefab;
    public GameObject playerUIPrefab;
    public GameObject inputModule;
    public Sprite characterSprite;
    public Sprite nameSprite;
    public Sprite infoSprite;


    public float maxHealth;
    public int amountOfJumps = 1;
}
