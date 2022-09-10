using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TowerPanel : MonoBehaviour
{
   [SerializeField] private RectTransform content;
   [SerializeField] private List<Tower> towerScrptObjects;
   [SerializeField] private List<Button> towerButtons;
   [SerializeField] private Button towerButtonPref;
   
   private void Awake()
   {
      Button tmp;
      for (int i = 0; i < towerScrptObjects.Count; i++)
      {
         tmp = Instantiate(towerButtonPref, content);
         tmp.GetComponent<TowerButton>().towerScrptObject = towerScrptObjects[i];
         towerButtons.Add(tmp);
      }
      
   }
   
}
