using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
   public GameObject panel;
   public GameObject winButton;
   public GameObject loseButton;
   public Text txt;
   private KeyCode keyCode;

   private void Update()
   {
      if (Input.GetKey(KeyCode.F))
      {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }

      if (Input.GetKey(KeyCode.Alpha1))
      {
         SceneManager.LoadScene(0);
      }
      
      if (Input.GetKey(KeyCode.Alpha2))
      {
         SceneManager.LoadScene(1);
      }
      
      if (Input.GetKey(KeyCode.Alpha3))
      {
         SceneManager.LoadScene(2);
      }
      
      if (Input.GetKey(KeyCode.Alpha4))
      {
         SceneManager.LoadScene(3);
      }
      
      if (Input.GetKey(KeyCode.Alpha5))
      {
         SceneManager.LoadScene(4);
      }
   }

   private void LoadScene(int sceneIndex)
   {
      SceneManager.LoadScene(sceneIndex);
   }

   public void Win()
   {
      panel.SetActive(true);
      winButton.SetActive(true);
      txt.text = "YOU WIN!";
   }

   public void Lose()
   {
      panel.SetActive(true);
      loseButton.SetActive(true);
      txt.text = "You lose!\nTry again.";
   }

   public void GoToNextLevel()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void RestartCurrentLevel()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}

