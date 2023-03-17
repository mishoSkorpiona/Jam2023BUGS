using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI damageText;

    public void SetDamage(float damage)
    {
        damageText.text = Mathf.Max(0, damage).ToString();
    }
}
