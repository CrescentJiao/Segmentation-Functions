using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeStart : MonoBehaviour
{
    public Sprite play;
    public Sprite timeout;
    public Slider slider;
    public static List<float> beespeed = new List<float>();
    public static List<float> timeuse = new List<float>();
    Text distancetext;
    // Start is called before the first frame update
    void Start()
    {
        beespeed.Clear();
        timeuse.Clear();
        //  GetComponent<Toggle>().interactable = false;
        beespeed.Add(0);
        timeuse.Add(0);
        GetComponent<Toggle>().onValueChanged.AddListener(OnClick);
        distancetext = GameObject.Find("distance").GetComponent<Text>();
    }
    void OnClick(bool ison)
    {
        if (ison == true)
        {
            Mytimer2.isStart = true;
            Mytimer2.isPause = false;
          
           BeeChangeSpeed.BeeSpeed= slider.value;
            beespeed.Add(slider.value);
            this.GetComponentInChildren<Image>().sprite = play;
            slider.interactable = false;
        }
        else if (ison == false)
        {
            Mytimer2.isPause = true;
            timeuse.Add(Mytimer2.m_Timer);
            this.GetComponentInChildren<Image>().sprite = timeout;
            slider.interactable = true;
            //Resources.Load("Textures/play" ) as Sprite;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (BeeStGraph.yy -100>0)
        {
            Mytimer2.isPause = true;
            distancetext.text =  "100.00m";
            slider.interactable = false ;
        }
     

    }
}
