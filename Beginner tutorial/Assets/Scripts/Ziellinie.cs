using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ziellinie : MonoBehaviour
{
    public Text txtBestTime;

    float time = 0;
    float besttime = float.MaxValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (time < besttime)
        {
            besttime = time;
            txtBestTime.text = $"Best Time: {besttime.ToString("0.##")} Sekunden";
        }
        time = 0;
    }
}
