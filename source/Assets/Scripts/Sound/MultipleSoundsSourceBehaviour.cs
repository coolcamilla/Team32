using UnityEngine;

public class MultipleSoundsSourceBehaviour : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _menuOpenedSound;
    [SerializeField] private AudioClip _buttonPressed;
    [SerializeField] private AudioClip _craftSound;
    [SerializeField] private AudioClip _coinCollectedSound;
    [SerializeField] private AudioClip _itemCollectedSound;
    [SerializeField] private AudioClip _beerDrinkingSound;

    private void Awake()
    { 
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMenuSound()
    {
        if (_menuOpenedSound != null)
        {
            _audioSource.PlayOneShot(_menuOpenedSound);
        }
    }
    public void PlayButtonSound()
    {
        if (_buttonPressed != null)
        {
            _audioSource.PlayOneShot(_buttonPressed);
        }
    }
    public void PlayCraftSound()
    {
        if (_craftSound != null)
        {
            _audioSource.PlayOneShot(_craftSound);
        }
    }

    public void PlayCoinCollectedSound()
    {
        if (_coinCollectedSound != null)
        {
            _audioSource.PlayOneShot(_coinCollectedSound);
        }
    }
    public void PlayItemCollectedSound()
    {
        if (_itemCollectedSound != null)
        {
            _audioSource.PlayOneShot(_itemCollectedSound);
        }
    }

    public void PlayBeerDrinkingSound()
    {
        if (_beerDrinkingSound != null)
        {
            _audioSource.PlayOneShot(_beerDrinkingSound);
        }
    }
}
