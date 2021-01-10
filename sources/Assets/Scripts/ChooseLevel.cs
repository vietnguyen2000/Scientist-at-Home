using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour
{
    public static int level = 1;
    public GameObject left;
    public GameObject right;
    public GameObject panel;
    public Button[] levels;
    private RectTransform[] levelsRect;
    private RectTransform rect;
    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log(Application.persistentDataPath);
        levelsRect = new RectTransform[levels.Length];
        rect = GetComponent<RectTransform>();
        int unlockedLevel = SaveLoadManager.Instance.SavedData.level;
        for (int i = 0 ; i < levels.Length; i ++){
            if (i > unlockedLevel){
                levels[i].interactable = false;
                
            }
            levelsRect[i] = levels[i].GetComponent<RectTransform>();
        }
        if (level !=1 ) {
            panel.GetComponent<RectTransform>().anchoredPosition -= new Vector2(277.2f*(level-1),0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float minDistance = Mathf.Infinity;
        float index =0;
        for (int i = 0 ; i < levelsRect.Length; i++){
            float d = Vector2.Distance(rect.position, levelsRect[i].position);
            Debug.Log(d);
            if (d < minDistance){
                index = i;
                minDistance = d;
            }
        }
        if(index == 0){
            left.SetActive(false);
            right.SetActive(true);
        }
        else if(index == levelsRect.Length-1){
            left.SetActive(true);
            right.SetActive(false);
        }
        else{
            left.SetActive(true);
            right.SetActive(true);
        }
    }
}
