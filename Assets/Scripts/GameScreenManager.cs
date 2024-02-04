using Hero;
using Lobby;
using UnityEngine;

public class GameScreenManager : MonoBehaviour
{
    [SerializeField] private LobbyScreenManager _lobbyScreenManager;
    [SerializeField] private HeroesManager _heroesManager;

    
    private void Start()
    {
        _lobbyScreenManager.Initialize(_heroesManager.HeroControllers);
    }
}