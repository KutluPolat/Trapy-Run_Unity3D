using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinions : MonoBehaviour
{
    public GameObject Minion;

    private List<GameObject> z4 = new List<GameObject>();
    private List<GameObject> z3 = new List<GameObject>();
    private List<GameObject> z2 = new List<GameObject>();
    private List<GameObject> z1 = new List<GameObject>();
    private List<GameObject> z0 = new List<GameObject>();
    private List<GameObject> z_1 = new List<GameObject>();
    private List<GameObject> z_2 = new List<GameObject>();
    private List<GameObject> z_3 = new List<GameObject>();
    private List<GameObject> z_4 = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("FillTheLinesWithMinions", 0, 1f);
    }
    private void FillTheLinesWithMinions()
    {
        if(z4.Count < 4)
        {
            var playerPosition = GameObject.Find("Player").transform.position;
            var newMinionPosition = new Vector3(playerPosition.x - 20, playerPosition.y, 4);

            var minion = Instantiate(Minion, newMinionPosition, Minion.transform.rotation);
            minion.name = "z4";
            z4.Add(minion);
        }

        if (z3.Count < 4)
        {
            var playerPosition = GameObject.Find("Player").transform.position;
            var newMinionPosition = new Vector3(playerPosition.x - 20, playerPosition.y, 3);

            var minion = Instantiate(Minion, newMinionPosition, Minion.transform.rotation);
            minion.name = "z3";
            z3.Add(minion);
        }

        if (z2.Count < 4)
        {
            var playerPosition = GameObject.Find("Player").transform.position;
            var newMinionPosition = new Vector3(playerPosition.x - 20, playerPosition.y, 2);

            var minion = Instantiate(Minion, newMinionPosition, Minion.transform.rotation);
            minion.name = "z2";
            z2.Add(minion);
        }

        if (z1.Count < 4)
        {
            var playerPosition = GameObject.Find("Player").transform.position;
            var newMinionPosition = new Vector3(playerPosition.x - 20, playerPosition.y, 1);

            var minion = Instantiate(Minion, newMinionPosition, Minion.transform.rotation);
            minion.name = "z1";
            z1.Add(minion);
        }

        if (z0.Count < 4)
        {
            var playerPosition = GameObject.Find("Player").transform.position;
            var newMinionPosition = new Vector3(playerPosition.x - 20, playerPosition.y, 0);

            var minion = Instantiate(Minion, newMinionPosition, Minion.transform.rotation);
            minion.name = "z0";
            z0.Add(minion);
        }

        if (z_1.Count < 4)
        {
            var playerPosition = GameObject.Find("Player").transform.position;
            var newMinionPosition = new Vector3(playerPosition.x - 20, playerPosition.y, -1);

            var minion = Instantiate(Minion, newMinionPosition, Minion.transform.rotation);
            minion.name = "z_1";
            z_1.Add(minion);
        }

        if (z_2.Count < 4)
        {
            var playerPosition = GameObject.Find("Player").transform.position;
            var newMinionPosition = new Vector3(playerPosition.x - 20, playerPosition.y, -2);

            var minion = Instantiate(Minion, newMinionPosition, Minion.transform.rotation);
            minion.name = "z_2";
            z_2.Add(minion);
        }

        if (z_3.Count < 4)
        {
            var playerPosition = GameObject.Find("Player").transform.position;
            var newMinionPosition = new Vector3(playerPosition.x - 20, playerPosition.y, -3);

            var minion = Instantiate(Minion, newMinionPosition, Minion.transform.rotation);
            minion.name = "z_3";
            z_3.Add(minion);
        }

        if (z_4.Count < 4)
        {
            var playerPosition = GameObject.Find("Player").transform.position;
            var newMinionPosition = new Vector3(playerPosition.x - 20, playerPosition.y, -4);

            var minion = Instantiate(Minion, newMinionPosition, Minion.transform.rotation);
            minion.name = "z_4";
            z_4.Add(minion);
        }
    }




}
