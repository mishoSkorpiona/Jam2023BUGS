using UnityEngine;
using UnityEngine.SceneManagement;

public class FightData : MonoBehaviour
{
    public bool loadFightSceneOnStart;
    public CharacterStats[] players;
    public int stageID = 2;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.activeSceneChanged += TryLoadFight;

        if (loadFightSceneOnStart)
            SceneManager.LoadSceneAsync("Fight Scene");
    }

    void TryLoadFight(Scene scene, Scene scene2)
    {
        Stage stage = FindObjectOfType<Stage>();

        if (!stage) return;

        stage.SpawnCharacters(players);
    }
}
