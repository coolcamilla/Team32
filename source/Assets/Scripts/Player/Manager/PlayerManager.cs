using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsCounterUI;

    private PlayerManagerLogic _logic;
    private PlayerInput _input;
    private UnityAction OnCoinsChanged;
    private PlayerStamina _playerStamina;

    public PlayerManagerLogic Logic => _logic;
    public Item EquippedItem => _logic.EquippedItem;
    public PlayerInput Input
    {
        get
        {
            if (_input == null) _input = new PlayerInput();
            return _input;
        }
    }

    public int Coins => _logic?.Coins ?? 0;

    private void OnEnable()
    {
        OnCoinsChanged += UpdateCoinsUI;
    }

    private void OnDisable()
    {
        OnCoinsChanged -= UpdateCoinsUI;
    }


    private void Initialize()
    {
        _logic = new PlayerManagerLogic();
        _playerStamina = GetComponent<PlayerStamina>();
        VideoPlayerController.OnVideoStarted += EndGame;
    }

    public void ChangeItem(Item item)
    {
        if (_logic == null) Initialize();
        _logic.ChangeItem(item);
    }

    public void AddCoin()
    {
        if (_logic == null) Initialize();
        _logic.AddCoin();
        OnCoinsChanged?.Invoke();
    }

    public bool TrySpendCoins(int number)
    {
        bool isSpent = _logic.TrySpend(number);
        if (isSpent)
        {
            OnCoinsChanged?.Invoke();
        }
        return isSpent;
    }

    private void UpdateCoinsUI()
    {
        _coinsCounterUI.SetText(_logic.Coins.ToString());
    }

    public void UpgradeStamina()
    {
        _playerStamina.Upgrade();
    }

    public void LoadCoins(int coins)
    {
        if (_logic == null) Initialize();
        _logic.SetCoins(coins);
        OnCoinsChanged?.Invoke();
    }

    private void EndGame()
    {
        _input.Disable();
    }

    public Collider2D GetBelowCollider()
    {
        return GetComponent<PlayerMovement>().GetBelowColliderWithBoxCast();
    }
}
