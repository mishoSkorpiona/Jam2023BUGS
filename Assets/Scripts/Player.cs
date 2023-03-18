using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerID;

    CharacterStats playerStats;

    PlayerUI myUI;

    private float _damage;
    float Damage
    {
        get => _damage;
        set
        {
            Damage = value;
            myUI.SetDamage(_damage);
        }
    }

    private void Start()
    {
        FightUI.Instance.AddUI(playerStats.playerUIPrefab);
    }

    public void TakeDamage(float damageAmount)
    {
        Damage -= damageAmount;
    }
}
