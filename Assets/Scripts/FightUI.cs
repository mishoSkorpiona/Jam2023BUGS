using UnityEngine;

public class FightUI : MonoBehaviour
{
    public RectTransform playerCharecterUIParent;
    public static FightUI Instance;

    private void Awake()
    {
        Instance = this;
    }

    public PlayerUI AddUI(GameObject uiPrefab)
    {
        GameObject newUI = Instantiate(uiPrefab, playerCharecterUIParent);
        PlayerUI uiScript = newUI.GetComponent<PlayerUI>();

        return uiScript;
    }
}
