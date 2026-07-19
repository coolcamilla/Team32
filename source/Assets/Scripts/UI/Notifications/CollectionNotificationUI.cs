using UnityEngine;
using System.Collections.Generic;

public class CollectionNotificationUI : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform _notificationContainer;
    [SerializeField] private GameObject _notificationPrefab;
    [SerializeField] private float _lifetime = 2f;
    [SerializeField] private int _maxNotifications = 3;
    [SerializeField] private float _fadeTime = 0.3f;

    private NotificationLogic _logic;
    private Dictionary<int, NotificationView> _activeViews = new Dictionary<int, NotificationView>();

    private void Start()
    {
        _logic = new NotificationLogic(_lifetime, _maxNotifications);
        _logic.OnNotificationAdded += HandleNotificationAdded;
        _logic.OnNotificationUpdated += HandleNotificationUpdated;
        _logic.OnNotificationExpired += HandleNotificationExpired;

        InventoryManager invManager = GameObject.FindWithTag("Game Manager").GetComponent<InventoryManager>();
        invManager.OnItemCollected += HandleItemCollected;
    }

    private void Update()
    {
        _logic.Tick(Time.deltaTime);
    }

    private void HandleItemCollected(Item item, int total)
    {
        string key = item.name;
        string text = $"Collected 1 {item.name} ({total} in total)";

        _logic.AddOrUpdateNotification(key, text);
    }

    private void HandleNotificationAdded(NotificationLogic.Notification notif)
    {
        GameObject go = Instantiate(_notificationPrefab, _notificationContainer);
        NotificationView view = go.GetComponent<NotificationView>();
        view.SetText(notif.Text);
        view.FadeIn(_fadeTime);

        _activeViews.Add(notif.Id, view);
    }

    private void HandleNotificationUpdated(NotificationLogic.Notification notif)
    {
        if (_activeViews.TryGetValue(notif.Id, out NotificationView view))
        {
            view.SetText(notif.Text);
        }
    }

    private void HandleNotificationExpired(int id)
    {
        if (_activeViews.TryGetValue(id, out NotificationView view))
        {
            _activeViews.Remove(id);
            view.FadeOutAndDestroy(_fadeTime);
        }
    }
}