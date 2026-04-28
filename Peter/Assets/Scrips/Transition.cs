using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition : MonoBehaviour
{
   public string scene;
   public void transition()
   {
       SceneManager.LoadScene(scene, LoadSceneMode.Single);
   }
 
}