using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Slider damageSlider;
    public float maxDamage;

    public void SetDamage(float damage)
    {
        damageSlider.value = damage / maxDamage;
    }
}
