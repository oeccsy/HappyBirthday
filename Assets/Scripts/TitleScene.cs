using UnityEngine;

public class TitleScene : MonoBehaviour
{
    TitleSceneUI titleSceneUI;
    Sound sound;

    private void Awake()
    {
        titleSceneUI = GetComponentInChildren<TitleSceneUI>();
        sound = GetComponentInChildren<Sound>();
    }

    private void Start()
    {
        titleSceneUI.StartButton.onClick.AddListener(LoadGameScene);
        sound.PlayTitleBGM();
    }

    public void LoadGameScene()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/GameScene"));
        Destroy(gameObject);
    }
}
