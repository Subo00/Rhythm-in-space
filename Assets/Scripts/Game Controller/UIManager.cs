using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   [SerializeField] private Image healthImage;
   [SerializeField] private TMP_Text scoreText;
   [SerializeField] private TMP_Text multiplierText;
   
   [System.Serializable]
   public struct PowerUp
   {
      public GameObject gameObject;
      public TMP_Text text;
   }
   [SerializeField] private PowerUp spreadUp;
   public void SetHealth(float value)
   {
      healthImage.fillAmount = value;
      if (healthImage.fillAmount < 0.2f) { SetHealthColor(Color.red); }
      else if (healthImage.fillAmount < 0.4f) { SetHealthColor(Color.yellow); }
      else { SetHealthColor(Color.green); }
   }

   public void SetMultiplier(int multiplier) {     multiplierText.text = multiplier.ToString(); }
   public void SetScore(int score)   { scoreText.text = score.ToString(); }

   public void SetSpreadTime(float time)
   {
      if(!spreadUp.gameObject.activeSelf) { spreadUp.gameObject.SetActive(true); }
      if (time <= 0) { spreadUp.gameObject.SetActive(false); }
      else { spreadUp.text.text = time.ToString("F1");}
   }

   private void SetHealthColor(Color healthColor) { healthImage.color = healthColor; }
   
   
}
