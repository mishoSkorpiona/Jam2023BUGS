using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSelectUI : MonoBehaviour
{
    public Image characterSprite;
    public Image nameSprite;
    public Image infoSprite;

    public void SetCharacter(CharacterStats stats)
    {
        characterSprite.sprite  = stats.characterSprite;
        characterSprite.color = Color.white;
        nameSprite.sprite       = stats.nameSprite;
        nameSprite.color = Color.white;
        infoSprite.sprite       = stats.infoSprite;
        infoSprite.color = Color.white;
    }
}
