using UnityEngine;
using PixelCrushers.DialogueSystem;

namespace PixelCrushers.DialogueSystem.Wrappers
{
    [AddComponentMenu("Pixel Crushers/Dialogue System/UI/Standard UI/Dialogue/Standard UI Response Button")]
    public class StandardUIResponseButton : PixelCrushers.DialogueSystem.StandardUIResponseButton
    {
        public TextPrinter textPrinterScript;

        public override void SetFormattedText(FormattedText formattedText)
        {
            base.SetFormattedText(formattedText);

            if (textPrinterScript != null)
                textPrinterScript.SetWriterText(UITools.GetUIFormattedText(formattedText));
        }
    }
}