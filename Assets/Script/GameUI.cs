using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    [SerializeField] private Text elapsedTimeText;

    [SerializeField] private Text playerScoreText;

    public void UpdateScore(int score) {
        playerScoreText.text = score.ToString().PadLeft(3, '0');
    }

    public void UpdateTime(float time) {
        elapsedTimeText.text = time.ToString("F2");
    }

}