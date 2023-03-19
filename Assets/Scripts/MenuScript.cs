using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuScript : MonoBehaviour
{
    public playerSelectUI[] playerSelectUIs;
    public Transform[] charactersToChooseFrom;
    public RectTransform[] selectorImages;
    public List<CharacterSelector> selectors;
    public List<PlayerInput> playerInputs;
    public CharacterStats[] stats;

    public Image startFight;

    public FightData fightData;

    int charCount = 0;

    public void getMyUI(CharacterSelector selector)
    {
        selector.selector = selectorImages[charCount];
        selector.selector.GetComponent<Image>().color = Color.white;
        selector.myUI = playerSelectUIs[charCount];

        charCount++;

        if (charCount > 1)
            startFight.color = Color.white;

    }

    public void SetCorrectParent(PlayerInput playerInput)
    {
        playerInputs.Add(playerInput);
        playerInput.transform.SetParent(charactersToChooseFrom[0].parent);
        playerInput.transform.SetSiblingIndex(0);
    }

    [ContextMenu("Start Fight")]
    public void StartFight()
    {
        if (charCount < 2) return;

        for (int i = 0; i < selectors.Count; i++)
        {

            CharacterStats instance = Instantiate(stats[selectors[i].currentChar]);

            instance.inputModule = playerInputs[i].gameObject;

            playerInputs[i].transform.parent = null;
            Destroy(playerInputs[i].transform.GetChild(0).gameObject);

            DontDestroyOnLoad(playerInputs[i].gameObject);

            fightData.players.Add(instance);

            Destroy(selectors[i]);
        }

        fightData.StartFight();
    }
}
