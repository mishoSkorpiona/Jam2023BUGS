using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLoader : MonoBehaviour
{
    public FightUI fightUI;

    private void Start()
    {
        FightData data = FindObjectOfType<FightData>();
        SceneManager.LoadSceneAsync(data.stageID, LoadSceneMode.Additive);
        fightUI.SetupUI(data.players);
    }
}
