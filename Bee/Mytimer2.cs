using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mytimer2 : MonoBehaviour
{


    public static float m_Timer;
    public static bool isPause = false;
    public static bool isStart = false;
    private int m_Hour;//时
    private int m_Minute;//分
    private int m_Second;//秒
                         // public static float Order[4]

    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        m_Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart == true)
        {
            if (!isPause)
            {

                m_Timer += Time.deltaTime;
                m_Second = (int)m_Timer;
                if (m_Second > 59.99f)
                {
                    m_Second = (int)(m_Timer - (m_Minute * 60));
                }
                m_Minute = (int)(m_Timer / 60);
                if (m_Minute > 59.99f)
                {
                    m_Minute = (int)(m_Minute - (m_Hour * 60));
                }
                m_Hour = m_Minute / 60;
                if (m_Hour >= 24.0f)
                {
                    m_Timer = 0;
                }
                this.GetComponent<Text>().text = string.Format("{0:f2}", m_Timer) + "s";
            }
            else
            {
                this.GetComponent<Text>().text = string.Format("{0:f2}", m_Timer) + "s";
            }

        }
        else
        {
            this.GetComponent<Text>().text = "00:00";
        }



    }

}
