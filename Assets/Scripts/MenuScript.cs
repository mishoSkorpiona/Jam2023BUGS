using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuScript : MonoBehaviour
{
    public Transform[] charactersToChooseFrom;
    public List<CharacterSelector> selectors;
    public List<PlayerInput> playerInputs;
    public CharacterStats[] stats;

    public FightData fightData;

    public void SetCorrectParent(PlayerInput playerInput)
    {
        playerInputs.Add(playerInput);
        playerInput.transform.SetParent(charactersToChooseFrom[0].parent);
        playerInput.transform.SetSiblingIndex(0);
    }

    [ContextMenu("Start Fight")]
    public void StartFight()
    {
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
