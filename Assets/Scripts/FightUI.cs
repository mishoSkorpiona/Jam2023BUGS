using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightUI : MonoBehaviour
{
    public RectTransform[] playerCharecterUIParents;
    public Slider[] slider;
    int characterCount;

    public void SetupUI(List<CharacterStats> characterStats)
    {
        foreach (var characterStat in characterStats)
            AddUI(characterStat);
    }

    public PlayerUI AddUI(CharacterStats characterStats)
    {
        GameObject newUI = Instantiate(characterStats.playerUIPrefab, playerCharecterUIParents[characterCount]);
        PlayerUI uiScript = newUI.GetComponent<PlayerUI>();

        uiScript.damageSlider = slider[characterCount];
        uiScript.maxDamage = characterStats.maxHealth;
        uiScript.SetDamage(characterStats.maxHealth);


        characterCount++;

        return uiScript;
    }
}
