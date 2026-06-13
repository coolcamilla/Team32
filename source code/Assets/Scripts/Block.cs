using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private BlockTypeData _blockData;
    
    private PlayerManager _player;
    private float _currentHp;
    private SpriteRenderer _spriteRenderer;
    private GameObject _stickPrefab;
    private GameObject _stonePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _player = GameObject.FindWithTag("Game Manager").GetComponent<PlayerManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_blockData == null )
        {
            Debug.LogError($"Block {gameObject.name} dont have BlockTypeData");
            return;
        }

        _currentHp = _blockData.maxHp;
        _spriteRenderer.color = _blockData.color;
        _stickPrefab = Resources.Load<GameObject>("Prefabs/Items/Resources/Stick Object");
        _stonePrefab = Resources.Load<GameObject>("Prefabs/Items/Resources/Stone Object");
    }


    private void OnMouseDown()
    {
        if (_blockData == null) return;

        Instrument instument = _player.CurrentInstrument;
        if (instument == null) return;

        if (instument.Damage < _blockData.minDamage)
        {
            Debug.Log("OMAGAD NEDOSTATOCHNO SILI, CHMO");
            return;
        }

        _currentHp -= instument.Damage;


        if (_spriteRenderer != null)
        {
            float dark = 1f - (float)_currentHp / _blockData.maxHp;
            _spriteRenderer.color = Color.Lerp(_blockData.color, Color.gray, dark);
        }

        if (_currentHp <= 0)
        {
            DropLoot();
            Destroy(gameObject);
        }
    }


    private void DropLoot()
    {
        InventoryManager inventory = InventoryManager.GetInstance;
        foreach (var drop in _blockData.dropTable)
        {
            if (Random.value < drop.chance)
            {
                if (drop.material == CraftMaterial.Stick) Instantiate(_stickPrefab, transform.position, Quaternion.identity);
                else Instantiate(_stonePrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
