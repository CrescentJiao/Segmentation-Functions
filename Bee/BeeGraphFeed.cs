#define Graph_And_Chart_PRO
using UnityEngine;
using ChartAndGraph;

using System.Collections;


public class BeeGraphFeed : MonoBehaviour
{
    float lastTime = 0f;

    GraphChartBase graph;
    void Start()
    {
        graph = GetComponent<GraphChartBase>();
        if (graph != null)
        {
            graph.Scrollable = false;
            graph.HorizontalValueToStringMap[0.0] = "0"; // example of how to set custom axis strings
            graph.DataSource.StartBatch();
            graph.DataSource.ClearCategory("Player 1");
            //  graph.DataSource.ClearAndMakeBezierCurve("Player 2");
            graph.DataSource.AddPointToCategory("Player 5", 0, 0);



            graph.DataSource.EndBatch();
        }
        // StartCoroutine(ClearAll());
        //  InvokeRepeating("MyAddPoint", 0.01f, 0.01f);
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
           if(BeeStGraph.yy <= 100)
            {
                graph.DataSource.AddPointToCategory("Player 4", Mytimer2.m_Timer, BeeChangeSpeed.BeeSpeed); // each time we call AddPointToCategory

            }



        }
    }
    IEnumerator ClearAll()
    {
        yield return new WaitForSeconds(5f);
        GraphChartBase graph = GetComponent<GraphChartBase>();

        graph.DataSource.Clear();
    }
}
