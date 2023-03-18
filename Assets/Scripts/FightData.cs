using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightData : MonoBehaviour
{
    public bool loadFightSceneOnStart;
    public List<CharacterStats> players;
    public int stageID = 2;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (loadFightSceneOnStart)
            StartFight();            
    }

    public void StartFight() => SceneManager.LoadSceneAsync("Fight Scene");
}
