using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Gradient gradient;
    public GradientColorKey[] colorKey;
    public GradientAlphaKey[] alphaKey;
    public Image fill;
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
        slider.interactable = false;
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
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }

    //Increase the progress bar
    public void Increment(float increaseValue)
    {
        slider.value += increaseValue;
    }
}
