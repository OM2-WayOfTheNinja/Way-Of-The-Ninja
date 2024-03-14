using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
   
  [SerializeField] private Button instrucations;
  [SerializeField] private Button back;

  [SerializeField] private GameObject instrucationsPanel;
  

  void Start()
  {
    instrucations.onClick.AddListener(ShowInstrucations);
    back.onClick.AddListener(ShowBack);
  }

  private void ShowInstrucations()
  {
    instrucationsPanel.SetActive(true);
    
  }

  private void ShowBack()
  {
    instrucationsPanel.SetActive(false);
  
  }

   
}
