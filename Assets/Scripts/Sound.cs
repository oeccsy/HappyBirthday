using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayTitleBGM()
    {
        audioSource.clip = Resources.Load<AudioClip>("Sound/TitleBGM");
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayHappyBirthday()
    {
        audioSource.clip = Resources.Load<AudioClip>("Sound/HappyBirthday");
        audioSource.loop = true;
        audioSource.Play();
    }
}
