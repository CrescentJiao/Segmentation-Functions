#define Graph_And_Chart_PRO
using UnityEngine;
using ChartAndGraph;

using System.Collections;
using UnityEngine.UI;


public class BeeStGraph : MonoBehaviour
{
    float lastTime = 0f;

    GraphChartBase graph;
    Text distancetext;
   // public static float y;
    public static  double yy;
    void Start()
    {
        yy = 0;
        distancetext = GameObject.Find("distance").GetComponent<Text>();
        distancetext.text = "00.00m";
        graph = GetComponent<GraphChartBase>();
        if (graph != null)
        {
            graph.Scrollable = false;
            graph.HorizontalValueToStringMap[0.0] = "0"; // example of how to set custom axis strings
            graph.DataSource.StartBatch();
            graph.DataSource.ClearCategory("Player 1");
            //  graph.DataSource.ClearAndMakeBezierCurve("Player 2");
            graph.DataSource.AddPointToCategory2("Player 5", 0, 50);



            graph.DataSource.EndBatch();
        }
        // StartCoroutine(ClearAll());
        //InvokeRepeating("MyAddPoint", 0.01f, 0.2f);
    }
    void Update()
    {
        MyAddPoint();
    }
    void MyAddPoint()
    {

        float curTime = Mytimer2.m_Timer;
        if (lastTime + 0.01f <= curTime)
        {
            lastTime = curTime;

            yy = SumBee()+BeeChangeSpeed.BeeSpeed * (Mytimer2.m_Timer - BeeStart.timeuse[BeeStart.timeuse.Count-1]);

            
            if (yy <= 100)
            {
                
                graph.DataSource.AddPointToCategory2("Player 4", Mytimer2.m_Timer, yy); // each time we call AddPointToCategory
                distancetext.text = yy.ToString("f2") + "m";
            }
               
            
           


        }
    }
    public float SumBee()
    {
        float sum = 0;
       
          sum = BeeStart.beespeed[0] * BeeStart.timeuse[0];
            for (int i = 1; i < BeeStart.timeuse.Count; i++)
            {

                sum = sum + BeeStart.beespeed[i] * (BeeStart.timeuse[i] - BeeStart.timeuse[i - 1]);

            }
        
       
        return sum;
    }
    IEnumerator ClearAll()
    {
        yield return new WaitForSeconds(5f);
        GraphChartBase graph = GetComponent<GraphChartBase>();

        graph.DataSource.Clear();
    }
}
