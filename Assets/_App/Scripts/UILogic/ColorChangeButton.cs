using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorChangeButton : MonoBehaviour
{
   public Image PreviewImage;

   private Image buttonImage;

   private void Start()
   {
      buttonImage = GetComponent<Image>();
   }

   public void SetColor()
   {
      PreviewImage.color = buttonImage.color;
   }
}
