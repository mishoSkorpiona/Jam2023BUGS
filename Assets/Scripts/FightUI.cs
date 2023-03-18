using UnityEngine;

public class FightUI : MonoBehaviour
{
    public RectTransform playerCharecterUIParent;

    public void SetupUI(CharacterStats[] characterStats)
    {
        foreach (var characterStat in characterStats)
            AddUI(characterStat.playerUIPrefab);
    }

    public PlayerUI AddUI(GameObject uiPrefab)
    {
        GameObject newUI = Instantiate(uiPrefab, playerCharecterUIParent);
        PlayerUI uiScript = newUI.GetComponent<PlayerUI>();

        return uiScript;
    }
}
