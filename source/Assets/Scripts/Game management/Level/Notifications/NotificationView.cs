using System.Collections;
using UnityEngine;
using TMPro;

public class NotificationView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        if (_canvasGroup == null) _canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void SetText(string text)
    {
        _text.text = text;
    }

    public void FadeIn(float time)
    {
        StartCoroutine(FadeRoutine(0, 1, time));
    }

    public void FadeOutAndDestroy(float time)
    {
        StartCoroutine(FadeOutRoutine(time));
    }

    private IEnumerator FadeRoutine(float from, float to, float time)
    {
        _canvasGroup.alpha = from;
        float timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            _canvasGroup.alpha = Mathf.Lerp(from, to, timer / time);
            yield return null;
        }
        _canvasGroup.alpha = to;
    }

    private IEnumerator FadeOutRoutine(float time)
    {
        yield return FadeRoutine(_canvasGroup.alpha, 0, time);
        Destroy(gameObject);
    }
}
