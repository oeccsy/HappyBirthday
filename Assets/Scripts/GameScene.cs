using UnityEngine;

public class GameScene : MonoBehaviour
{
    GameSceneUI gameSceneUI;
    Sound sound;

    Woodroom woodroom;
    PlayerCharacter playerCharacter;
    NPC npc;

    private void Awake()
    {
        gameSceneUI = GetComponentInChildren<GameSceneUI>();
        sound = GetComponentInChildren<Sound>();

        woodroom = GetComponentInChildren<Woodroom>();
        playerCharacter = GetComponentInChildren<PlayerCharacter>();
        npc = GetComponentInChildren<NPC>();
    }

    private void Start()
    {
        gameSceneUI.NwButton.onClick.AddListener(() => playerCharacter.MoveUp(woodroom));
        gameSceneUI.NeButton.onClick.AddListener(() => playerCharacter.MoveRight(woodroom));
        gameSceneUI.SwButton.onClick.AddListener(() => playerCharacter.MoveLeft(woodroom));
        gameSceneUI.SeButton.onClick.AddListener(() => playerCharacter.MoveDown(woodroom));

        sound.PlayHappyBirthday();
    }
}
