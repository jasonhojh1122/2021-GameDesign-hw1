using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Crane crane;

    [SerializeField] private Camera blurCamera;

    [SerializeField] private EndUI endUI;

    [SerializeField] private GameUI gameUI;

    private const float maxGameTime = 60f;

    private float elapsedTime;

    private int score;

    private bool ended;

    private void Awake() {
        score = 0;
        elapsedTime = 0f;
    }

    private void Start() {
        blurCamera.gameObject.SetActive(false);
        endUI.gameObject.SetActive(false);
    }

    private void Update() {
        if (!ended) {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > maxGameTime)
                EndGame();
            else {
                ProcessKey();
                gameUI.UpdateScore(score);
                gameUI.UpdateTime(elapsedTime);
            }
        }
    }

    void EndGame() {
        blurCamera.gameObject.SetActive(true);
        endUI.gameObject.SetActive(true);
        endUI.SetScore(score);
        ended = true;
    }

    private void ProcessKey() {
        if (Input.GetKey(KeyCode.W)) {
            crane.Move(Crane.Direction.UP);
        }
        if (Input.GetKey(KeyCode.S)) {
            crane.Move(Crane.Direction.DOWN);
        }
        if (Input.GetKey(KeyCode.A)) {
            crane.Move(Crane.Direction.LEFT);
        }
        if (Input.GetKey(KeyCode.D)) {
            crane.Move(Crane.Direction.RIGHT);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            crane.Operate();
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            EndGame();
        }
        if (!Input.anyKey) {
            crane.Move(Crane.Direction.STOP);
        }
    }

    public void AddScore(int score) {
        this.score += score;
    }

}
