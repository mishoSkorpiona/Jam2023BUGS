using UnityEngine;
using UnityEngine.InputSystem;

public class MessageExtender : MonoBehaviour
{
    GameObject FirstChild
    {
        get
        {
            return transform.GetChild(0).gameObject;
        }
    }

    void OnMove(InputValue input) => FirstChild.SendMessage("OnMove", input);
    void OnJump(InputValue input) => FirstChild.SendMessage("OnJump");
    void OnShield(InputValue input) => FirstChild.SendMessage("OnShield");
    void OnAttackNorth(InputValue input) => FirstChild.SendMessage("OnAttackNorth");
}
