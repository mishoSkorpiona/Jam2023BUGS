using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSelector : MonoBehaviour
{
    public Transform[] characters;
    public int _currentChar;
    public int currentChar
    {
        get => _currentChar;
        set
        {
            _currentChar = value;
            _currentChar %= characters.Length;
            if (_currentChar < 0) _currentChar = characters.Length - 1;
            transform.position = characters[_currentChar].position;
        }
    }
    public float minHorizontal = 0.3f;

    public bool selected;
    bool awaitingAnotherInput;

    private void Start()
    {
        MenuScript menu = FindObjectOfType<MenuScript>();
        characters = menu.charactersToChooseFrom;
        menu.selectors.Add(this);

        currentChar = 0;
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
    }
}
