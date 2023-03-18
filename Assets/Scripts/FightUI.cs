using UnityEngine;

public class FightUI : MonoBehaviour
{
    public RectTransform playerCharecterUIParent;

    public void SetupUI(CharacterStats[] characterStats)
    {
        foreach (var characterStat in characterStats)
            AddUI(characterStat);
    }

    public PlayerUI AddUI(CharacterStats characterStats)
    {
        GameObject newUI = Instantiate(characterStats.playerUIPrefab, playerCharecterUIParent);
        PlayerUI uiScript = newUI.GetComponent<PlayerUI>();
        uiScript.SetDamage(characterStats.maxHealth);

        return uiScript;
    }
}
