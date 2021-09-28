using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _boardRoot;

    [SerializeField] private Crane crane;

    [SerializeField] private Text _elapsedTimeFromStartText;

    private const int Width = 6;
    private const int Height = 10;

    private const int MiddleX = Width / 2;
    private const int Top = Height - 1;

    private const float MaxElapsedTimePerStep = 0.3f;
    private const float MaxElapsedTimeFromStart = 60f;

    private float _elapsedTimeFromStart;

    private float ElapsedTimeFromStart
    {
        get => _elapsedTimeFromStart;

        set
        {
            _elapsedTimeFromStart = value;
            _elapsedTimeFromStartText.text = _elapsedTimeFromStart.ToString("F2");
        }
    }

    private IEnumerator Start()
    {
        Debug.Log("start");
        while (true)
        {
            yield return PlayGame();
        }
    }

    private IEnumerator PlayGame()
    {
        ElapsedTimeFromStart = 0f;
        var elapsedTime = 0f;

        while (ElapsedTimeFromStart <= MaxElapsedTimeFromStart)
        {
            ElapsedTimeFromStart += Time.deltaTime;
            elapsedTime += Time.deltaTime;

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

            yield return null;
        }

        // GameOver
        ElapsedTimeFromStart = Mathf.Min(ElapsedTimeFromStart, MaxElapsedTimeFromStart);

        yield return new WaitForSeconds(1f);


    }
}
