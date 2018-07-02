using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectNum : MonoBehaviour {
  public void OnEndDrag(  ){

    float max = 9f; // 要素数-1
    float pos = Mathf.Clamp(this.GetComponent<ScrollRect>().verticalNormalizedPosition, 0, 1);
    int num = Mathf.RoundToInt(max - max * pos);
    Debug.Log(num);
    this.GetComponent<ScrollRect>().verticalNormalizedPosition = Mathf.RoundToInt(max * pos) / max;
  
  }

}