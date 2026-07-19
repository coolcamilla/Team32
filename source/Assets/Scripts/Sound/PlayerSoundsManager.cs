using UnityEngine;

public class PlayerSoundsManager : MonoBehaviour
{
    [SerializeField] private AudioClip _playerDeathSound;
    [SerializeField] private AudioClip _playerLandingSound;
    [SerializeField] private AudioClip _playerDiggingBarehandSound;
    [SerializeField] private AudioClip _playerDiggingShovelSound;
    [SerializeField] private AudioClip _playerDiggingPickaxeSound;
    [SerializeField] private AudioClip _playerWalkingGrassSound;
    [SerializeField] private AudioClip _playerWalkingDirtSound;
    [SerializeField] private AudioClip _playerWalkingStoneSound;

    private AudioSource _audioSource;
    private PlayerManager _playerManager;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _playerManager = GetComponent<PlayerManager>();
    }

    public void PlayPLayerDeathSound()
    {
        if (_playerDeathSound != null)
        {
            _audioSource.PlayOneShot(_playerDeathSound);
        }
    }
    public void PlayPLayerLandingSound()
    {
        if (_playerLandingSound != null)
        {
            _audioSource.PlayOneShot(_playerLandingSound);
        }
    }
    public void PlayPLayerDiggingSound()
    {
        AudioClip desiredClip;

        switch (_playerManager.EquippedItem.Type)
        {
            case ItemType.WoodenShovel:
            case ItemType.StoneShovel:
                desiredClip = _playerDiggingShovelSound;
                break;
            case ItemType.StonePickaxe:
            case ItemType.FlintPickaxe:
            case ItemType.CopperPickaxe:
                desiredClip = _playerDiggingPickaxeSound;
                break;
            default:
                desiredClip = _playerDiggingBarehandSound;
                break;
        }

        if (desiredClip != null)
        {
            _audioSource.PlayOneShot(desiredClip);
        }
    }

    public void PlayWalkingSound()
    {
        if (_playerWalkingStoneSound != null)
        {
            _audioSource.PlayOneShot(_playerWalkingStoneSound);
        }
    }
}
