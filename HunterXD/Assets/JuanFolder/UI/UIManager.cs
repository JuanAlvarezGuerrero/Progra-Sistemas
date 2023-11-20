using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public interface IActorUIManagerProvider
{
    ActorUIManager ActorUIManager { get; }
}

public class UIManager : MonoBehaviour, IActorUIManagerProvider
{
    public static UIManager Instance;
    [SerializeField] private ActorUIManager actorUIManager;
    public ActorUIManager ActorUIManager => actorUIManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
}
[System.Serializable]
public class ActorUIManager
{
    [SerializeField] private TMP_Text playerHealthText;

    private Dictionary<string, Action<int>> actorActionsOnUpdateHealth;

    public void UpdateActorHealth(string actorID, int healthLeft)
    {
        if (actorActionsOnUpdateHealth == null)
        {
            InitializeDictionary();
        }
        if (actorActionsOnUpdateHealth.TryGetValue(actorID, out var onUpdateHealth))
        {
            onUpdateHealth.Invoke(healthLeft);
        }
    }
    private void InitializeDictionary()
    {
        actorActionsOnUpdateHealth = new();
        actorActionsOnUpdateHealth.Add(ActorConstants.PLAYER_ID, UpdatePlayerHealth);
    }
    public void UpdatePlayerHealth(int playerHealth)
    {
        playerHealthText.text = playerHealth.ToString();
    }
}

