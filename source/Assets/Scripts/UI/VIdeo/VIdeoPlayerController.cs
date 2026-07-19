using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _videoPlayer;

    public static event UnityEngine.Events.UnityAction OnVideoStarted;

    private void Awake()
    {
        _videoPlayer.GetComponent<VideoPlayer>().loopPointReached += EndGame;
    }

    public void PlayVideo()
    {
        OnVideoStarted?.Invoke();
        _videoPlayer.SetActive(true);
    }

    private void EndGame(VideoPlayer vp)
    {
        GetComponent<SceneLoader>().LoadSceneByIndex(0);
    }
}
