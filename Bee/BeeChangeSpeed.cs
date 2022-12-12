using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeChangeSpeed : MonoBehaviour
{
    public  static  float  BeeSpeed;
    Slider slider;
    public Text Vtext;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        BeeSpeed = slider.value;
      //  transform.GetComponent<InputField>().onValueChanged.AddListener(ChangedValue);//用户输入文本时就会调用
      //  transform.GetComponent<InputField>().onEndEdit.AddListener(EndValue);//文本输入结束时会调用
    }
    
//用户输入时的变化
private void ChangedValue(string value)
    {
       // valueText = value;//将用户输入的值赋值给内部的空字符串，我们可以将其来进行后续的操作
        Debug.Log("输入了" + value);
        Mytimer2.isPause = true;
    }
    private void EndValue(string    value)
    {
        if (float.Parse(value) <= 10.0)
        {
            BeeSpeed = float.Parse(value);//捕捉数据，方便后续操作
        }else if (float.Parse(value) > 10.0)
        {
            BeeSpeed = 10.0f;//捕捉数据，方便后续操作
        }
       
        Debug.Log("最终内容" + value);
        Mytimer2.isStart = true;
        Mytimer2.isPause =false;
    }

    // Update is called once per frame
    void Update()
    {
        Vtext.text = "速度:     " + slider.value + "      m/s";
    }
}
