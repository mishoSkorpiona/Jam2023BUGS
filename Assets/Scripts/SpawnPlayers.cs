using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private List<PlayerInput> playerInputs = new List<PlayerInput>();

    void Start()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        GameObject playerGO = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        PlayerInput playerInput = playerGO.GetComponent<PlayerInput>();
        playerInputs.Add(playerInput);
    }

    void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (change == InputDeviceChange.Added)
        {
            SpawnPlayer();
        }
    }

    void OnDestroy()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
    }
}