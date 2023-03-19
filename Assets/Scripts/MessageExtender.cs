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
    void OnShield(InputValue input)
    {
         Debug.Log(input.Get<float>());
    }

    void OnAttackNorth(InputValue input) => FirstChild.SendMessage("OnAttackNorth");
    void OnAttackSouth(InputValue input) => FirstChild.SendMessage("OnAttackSouth");
    void OnAttackEast(InputValue input) => FirstChild.SendMessage("OnAttackEast");
    void OnAttackWest(InputValue input) => FirstChild.SendMessage("OnAttackWest");
}
