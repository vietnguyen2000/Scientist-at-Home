using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float Value {
        get => slider.value;
        set => slider.value = value;
    }
    public Slider slider;
    public float decreasementSpeed = 0.2f;

    // Start is called before the first frame update
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Decrease the progress bar percent
        if (slider.value > 0)
        {
            slider.value -= decreasementSpeed * Time.deltaTime;
        }
    }

    //Increase the progress bar
    public void Increment(float increaseValue)
    {
        slider.value += increaseValue;
    }
}
