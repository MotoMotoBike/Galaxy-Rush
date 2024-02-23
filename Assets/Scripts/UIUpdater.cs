using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _score;
    [SerializeField] private GameObject[] indicators;
    void Start()
    {
        _player.OnHealthChanged += HealthUpdateUI;
        _player.OnScoreChanged += ScoreUpdateUI;
    }
    void OnDestroy()
    {
        _player.OnHealthChanged -= HealthUpdateUI;
        _player.OnScoreChanged -= ScoreUpdateUI;
    }
    private void ScoreUpdateUI(int value)
    {
        _score.text = value.ToString();
    }

    private void HealthUpdateUI(int value)
    {
        indicators.ToList().ForEach(i => i.gameObject.SetActive(false));
        for(var i = 0; i < value ; i++)
        {
            indicators[i].SetActive(true);
        }
    }
}
