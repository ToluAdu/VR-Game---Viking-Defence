using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityhealthbarUI : MonoBehaviour
{
    public Image ImgHealthBar;
    public Text TxtHealth;
    public int Min;
    public int Max;
    private int mCurrentValue;
    private float mCurrentPercent;

    GameObject h1, h2, h3, h4, h5;
    
    // Start is called before the first frame update


   /*     public void SetHealth(int health)
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
            ImgHealthBar.fillAmount = mCurrentPercent;
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
*/
    void Start()
    {
        h1 = GameObject.Find("heart1");
        h2 = GameObject.Find("heart2");
        h3 = GameObject.Find("heart3");
        h4 = GameObject.Find("heart4");
        h5 = GameObject.Find("heart5");
    }

    private void Update()
    {
        GameObject playa = GameObject.FindWithTag("castle");
        int health = playa.GetComponent<Castlehealthbar>().health;
        //SetHealth(health);
        if (health==100)
        {
            h1.SetActive(true);

            h2.SetActive(true);

            h3.SetActive(true);

            h4.SetActive(true);

            h5.SetActive(true);

        }

        if (health==80)
        {

            h1.SetActive(false);

        }
       else if (health == 60)
        {

            h2.SetActive(false);


        }
      else  if (health == 40)
        {

            h3.SetActive(false);

        }
       else if (health == 20)
        {

            h4.SetActive(false);

        }
       else if (health == 0)
        {

            h5.SetActive(false);

        }



    }

}
