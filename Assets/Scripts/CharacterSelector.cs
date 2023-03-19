using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSelector : MonoBehaviour
{
    public MenuScript menu;

    public RectTransform selector;

    public playerSelectUI myUI;
    public Transform[] characters;
    public CharacterStats[] stats;
    public int _currentChar;
    public int currentChar
    {
        get => _currentChar;
        set
        {
            _currentChar = value;
            _currentChar %= characters.Length;
            if (_currentChar < 0) _currentChar = characters.Length - 1;
            selector.position = characters[_currentChar].position;
        }
    }
    public float minHorizontal = 0.3f;

    public bool selected;
    bool awaitingAnotherInput;

    private void Start()
    {
        menu = FindObjectOfType<MenuScript>();
        characters = menu.charactersToChooseFrom;
        stats = menu.stats;
        menu.selectors.Add(this);

        menu.getMyUI(this);

        currentChar = 0;

        myUI.SetCharacter(stats[currentChar]);
    }

    void OnMove(InputValue input)
    {
        Vector2 dir = input.Get<Vector2>();

        if (Mathf.Abs(dir.x) < minHorizontal)
        {
            awaitingAnotherInput = false;
            return;
        }

        if (awaitingAnotherInput) return;

        awaitingAnotherInput = true;

        if (dir.x > 0)
            currentChar++;
        else
            currentChar--;

        myUI.SetCharacter(stats[currentChar]);
    }

    void OnJump()
    {
        menu.StartFight();
    }
}
