using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Conveyor : MonoBehaviour, ISlot {

    protected class PositionComparer: IComparer<Container> {
        public int Compare(Container x, Container y) {
            if (x.transform.position.x < y.transform.position.x) {
                return -1;
            }
            else if (x.transform.position.x > y.transform.position.x) {
                return 1;
            }
            else {
                return 0;
            }
        }
    }

    [SerializeField] private float speed;
    [SerializeField] private List<Transform> stopPoints;

    private PositionComparer comparer;
    private List<Container> containers;
    private float threshold;

    void Start() {
        comparer = new PositionComparer();
        containers = new List<Container>();
        threshold = stopPoints[1].position.x - stopPoints[0].position.x;
    }

    void Update() {
        Move();
    }

    public bool Store(Container con) {
        if (containers.Count == stopPoints.Count) {
            return false;
        }
        int res = containers.BinarySearch(con, comparer);
        if (res >= 0) {
            return false;
        }
        else if (res < 0) {
            res = ~res;
        }
        if (res < containers.Count && res >= 1 &&
            (con.transform.position.x - containers[res-1].transform.position.x < threshold ||
            containers[res].transform.position.x - con.transform.position.x < threshold)) {
            return false;
        }
        else {
            containers.Insert(res, con);
            containers[res].transform.SetParent(gameObject.transform);
            Vector3 newPos = containers[res].gameObject.transform.localPosition;
            newPos.y = 0;
            containers[res].gameObject.transform.localPosition = newPos;
            return true;
        }
    }

    public void Retrive(Container con) {
        Debug.Log("Conveyor retrive");
        int res = containers.BinarySearch(con, comparer);
        if (res < 0) {
            Debug.Log("Retrive fail");
            return;
        }
        containers.RemoveAt(res);
    }

    public bool IsFull() {
        return containers.Count == stopPoints.Count;
    }

    private void Move() {
        for (int i = 0; i < containers.Count; i++) {
            if (containers[i].transform.position.x > stopPoints[i].position.x) {
                Vector3 newPos = containers[i].transform.position;
                newPos.x -= speed * Time.deltaTime;
                containers[i].transform.position = newPos;
            }
        }
    }

    public void Touch() {
        return;
    }

}