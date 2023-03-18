using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerID;

    public CharacterStats playerStats;

    public Rigidbody2D myRigidbody;

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

    public void TakeDamage(float damageAmount)
    {
        Damage -= damageAmount;
    }
}
