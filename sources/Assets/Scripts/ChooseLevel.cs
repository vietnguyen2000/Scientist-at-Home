using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour
{
    public Button[] levels;
    // Start is called before the first frame update
    void OnEnable()
    {
        int unlockedLevel = SaveLoadManager.Instance.SavedData.level;
        for (int i = 0 ; i < levels.Length; i ++){
            if (i+1 > unlockedLevel){
                levels[i].interactable = false;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
