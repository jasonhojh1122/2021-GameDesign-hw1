using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BoatGenerator : MonoBehaviour {

    [SerializeField] private GameManager gm;
    [SerializeField] private ContainerGenerator cg;
    [SerializeField] private List<ABoat> boats;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform stopPoint;
    [SerializeField] private Transform leavePoint;


    private List<float> CDF;

    private ABoat curBoat;
    private List<ABoat> endBoats;

    void Start() {
        endBoats = new List<ABoat>();
        CDF = new List<float>();
        for (int i = 0; i < boats.Count; i++)
            CDF.Add(0.0f);
        GenerateBoat();
    }

    void Update() {
        if (curBoat.IsSatisfy()) {
            curBoat.MoveTo(leavePoint.position);
            endBoats.Add(curBoat);
            GenerateBoat();
        }
        CheckEnd();
    }

    void CheckEnd() {
        int c = 0;
        for (int i = 0; i-c < endBoats.Count; i++) {
            if (endBoats[i-c].IsStop()) {
                ABoat tmp = endBoats[i-c];
                endBoats.RemoveAt(i-c);
                gm.AddScore(tmp.GetScore());
                tmp.Leave();
            }
        }
    }

    void GenerateBoat() {
        CalculateCDF();
        float rand = UnityEngine.Random.Range(0.0f, 1.0f);
        int res = CDF.BinarySearch(rand);
        if (res < 0) {
            res = ~res;
        }
        curBoat = Instantiate(boats[res], spawnPoint.position, Quaternion.identity);
        for (int i = 0; i < curBoat.SlotNum; i++) {
            string type = cg.GenerateContainerType();
            curBoat.SetSlotType(i, cg.GetContainer(type));
        }
        curBoat.MoveTo(stopPoint.position);
    }

    void CalculateCDF() {
        for (int i = 0; i < boats.Count; i++) {
            CDF[i] = boats[i].GetWeight(Time.time);
            if (i > 0) {
                CDF[i] += CDF[i-1];
            }
        }
        for (int i = 0; i < CDF.Count; i++) {
            CDF[i] /= CDF[CDF.Count-1];
        }
    }


}