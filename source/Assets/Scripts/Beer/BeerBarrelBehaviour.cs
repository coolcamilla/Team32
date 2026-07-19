using UnityEngine;

public class BeerBarrelBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _textHint;
    [SerializeField] private Color _beerColor;
    [SerializeField] private Color _noBeerColor;
    
    private PlayerManager _playerManager;
    private PlayerInput _input;
    private GameObject _beerParticlesPrefab;

    private void Awake()
    {
        _playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        
        _input = new PlayerInput();
        _input.Player.Interact.performed += ctx => TryBuyBeer();

        _beerParticlesPrefab = Resources.Load<GameObject>("Prefabs/Particles/BeerParticles");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _textHint.SetActive(true);
            _input.Enable();
            _playerManager.Input.Player.Dig.Disable();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _textHint.SetActive(false);
            _input.Disable();
            _playerManager.Input.Player.Dig.Enable();
        }
    }

    private void TryBuyBeer()
    {
        if (_playerManager.TrySpendCoins(5))
        {
            _playerManager.UpgradeStamina();
            SpawnBeerParticles(_beerColor);
        }
        else SpawnBeerParticles(_noBeerColor);
    }

    private void SpawnBeerParticles(Color color)
    {
        if (_beerParticlesPrefab != null)
        {
            Vector3 spawnPos = _playerManager.transform.position + new Vector3(0, 3.5f, 0);
            GameObject particles = Instantiate(_beerParticlesPrefab, spawnPos, Quaternion.identity);

            var mainModule = particles.GetComponent<ParticleSystem>().main;
            mainModule.startColor = color;
        }
    }
}
