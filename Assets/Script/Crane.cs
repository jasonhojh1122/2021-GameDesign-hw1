using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Crane : MonoBehaviour {

    public enum Direction {
        RIGHT,
        LEFT,
        UP,
        DOWN,
        STOP
    }

    public Magnet magnet;

    [SerializeField] private float XMin;
    [SerializeField] private float XMax;
    [SerializeField] private float YMin;
    [SerializeField] private float YMax;

    [SerializeField] private float baseSpeed;
    [SerializeField] private float magnetSpeed;

    [SerializeField] private GameObject craneBase;

    private Direction curDir;
    private Animator anim;

    private Dictionary<Direction, string> animState;

    void Awake() {
        animState = new Dictionary<Direction, string>();
        animState.Add(Direction.RIGHT, "Right");
        animState.Add(Direction.LEFT, "Left");
        animState.Add(Direction.STOP, "Stop");
        curDir = Direction.STOP;
        anim = craneBase.GetComponent<Animator>();
    }

    public void Operate()
    {
        if (magnet.IsWithContainer()) {
            PutDown();
        }
        else {
            PickUp();
        }
    }

    public void PickUp()
    {
        if (magnet.IsOnContainer()) {
            magnet.PickUp();
        }
    }

    public void PutDown()
    {
        magnet.PutDown();
    }


    public void Move(Direction dir)
    {
        if (dir == Direction.STOP)
            Stop();
        else if (dir == Direction.RIGHT || dir == Direction.LEFT)
            MoveBase(dir);
        else
            MoveMagnet(dir);
    }

    private void Stop()
    {
        anim.Play(animState[Direction.STOP]);
    }


    private void MoveBase(Direction dir)
    {
        Vector3 newPos = gameObject.transform.localPosition;
        switch(dir) {
            case Direction.RIGHT:
                newPos.x += baseSpeed * Time.deltaTime;
                break;
            case Direction.LEFT:
                newPos.x -= baseSpeed * Time.deltaTime;
                break;
        }
        newPos.x = Mathf.Clamp(newPos.x, XMin, XMax);
        gameObject.transform.localPosition = newPos;

        if (dir != curDir) {
            anim.Play(animState[dir]);
        }
    }

    private void MoveMagnet(Direction dir)
    {
        Vector3 newPos = magnet.transform.localPosition;
        switch(dir) {
            case Direction.UP:
                newPos.y += magnetSpeed * Time.deltaTime;
                break;
            case Direction.DOWN:
                newPos.y -= magnetSpeed * Time.deltaTime;
                break;
        }
        newPos.y = Mathf.Clamp(newPos.y, YMin, YMax);
        magnet.transform.localPosition = newPos;
    }

}