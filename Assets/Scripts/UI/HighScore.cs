using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void Start()
    {
        GameEventManager.StartGame += Destroy;
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            _text.text = $"Best Score: {PlayerPrefs.GetInt("SaveScore")}";
        }
        else
        {
            _text.text = "Best Score: 0";
        }
    }

    private void Destroy()
    {
        UIManager.Instance.Close(gameObject);
    }

    private void OnDestroy()
    {
        GameEventManager.StartGame -= Destroy;
    }
}
