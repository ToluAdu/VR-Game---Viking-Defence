using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerhealthbarUI : MonoBehaviour
{
    public Image ImgHealthBar;
    public Slider Img;
    public Text TxtHealth;
    public int Min;
    public int Max;
    private int mCurrentValue;
    private float mCurrentPercent;
    // Start is called before the first frame update


        public void SetHealth(int health)
    {
        if(health != mCurrentValue)
        {
            if(Max - Min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = health;
                mCurrentPercent = (float)mCurrentValue / (float)(Max - Min);
            }

            TxtHealth.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercent*100));
            Img.value = mCurrentPercent;
            //fillAmount ImgHealthBar
        }
    }


    public float CurrentPercent
    {
        get
        {
            return mCurrentPercent;
        }
    }

    public int CurrentValue
    {
        get
        {
            return mCurrentValue;
        }
    }

    void Start()
    {
        
    }

    private void Update()
    {
        GameObject playa = GameObject.FindWithTag("Player");
        int health = playa.GetComponent<playerhealthbar>().health;
        SetHealth(health);
        Img.value = mCurrentPercent;
    }

}
