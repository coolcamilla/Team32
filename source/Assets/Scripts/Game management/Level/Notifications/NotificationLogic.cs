using UnityEngine;
using System;
using System.Collections.Generic;

public class NotificationLogic
{
    public class Notification
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public String Text { get; set; }
        public float Timer { get; set; }
    }

    private List<Notification> _activeNotifications = new List<Notification>();
    private int _nextId = 0;

    private readonly float _lifeTime;
    private readonly int _maxNotifications;

    public IReadOnlyList<Notification> ActiveNotifications => _activeNotifications;

    public event Action<Notification> OnNotificationAdded;
    public event Action<Notification> OnNotificationUpdated;
    public event Action<int> OnNotificationExpired;

    public NotificationLogic(float lifeTime, int maxNotifications)
    {
        _lifeTime = lifeTime;
        _maxNotifications = maxNotifications;
    }

    public void AddOrUpdateNotification(string key, string text)
    {
        for (int i = 0; i < _activeNotifications.Count; i++)
        {
            if (_activeNotifications[i].Key == key)
            {
                _activeNotifications[i].Text = text;
                _activeNotifications[i].Timer = _lifeTime;
                OnNotificationUpdated?.Invoke(_activeNotifications[i]);
                return;
            }
        }

        Notification newNotif = new Notification
        {
            Id = _nextId++,
            Key = key,
            Text = text,
            Timer = _lifeTime
        };

        _activeNotifications.Add(newNotif);
        OnNotificationAdded?.Invoke(newNotif);

        if (_activeNotifications.Count > _maxNotifications)
        {
            ExpireNotification(0);
        }
    }

    private void ExpireNotification(int index)
    {
        Notification notif = _activeNotifications[index];
        _activeNotifications.Remove(notif);
        OnNotificationExpired?.Invoke(notif.Id);
    }

    public void Tick(float deltaTime)
    {
        for (int i = _activeNotifications.Count - 1; i >= 0; i--)
        {
            _activeNotifications[i].Timer -= deltaTime;
            if (_activeNotifications[i].Timer <= 0)
            {
                ExpireNotification(i);
            }
        }
    }
}
