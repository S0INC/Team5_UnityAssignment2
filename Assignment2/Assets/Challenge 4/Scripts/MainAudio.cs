using UnityEditor.SearchService;
using UnityEngine;

public class MainAudio : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    public AudioClip background;
    public AudioClip buttonHover;
    public AudioClip ButtonSelect;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }

}
