using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour {

    [SerializeField] private Text finalScoreText;

    public void SetScore(int score) {
        finalScoreText.text = score.ToString().PadLeft(3, '0');
    }

    public void Restart() {
        SceneManager.LoadScene(1);
    }

    public void Menu() {
        SceneManager.LoadScene(0);
    }

}