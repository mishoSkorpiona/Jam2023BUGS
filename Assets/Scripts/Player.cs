using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerID;

    public CharacterStats playerStats;

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

    public void SetUpUI()
    {
        FightUI.Instance.AddUI(playerStats.playerUIPrefab);
    }

    public void TakeDamage(float damageAmount)
    {
        Damage -= damageAmount;
    }
}
