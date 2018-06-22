using UIKit;

namespace MoreBotProgrammer.iOS
{
    public static class ButtonStyle
    {
        public static void Apply(params UIButton[] buttons)
        {
            foreach (var button in buttons) {
                button.BackgroundColor = Colors.Primary;
                button.SetTitleColor(Colors.LightText, UIControlState.Normal);
                button.SetTitleColor(Colors.LightText.ColorWithAlpha(0.75f), UIControlState.Highlighted);
                button.SetTitleColor(Colors.LightText.ColorWithAlpha(0.5f), UIControlState.Disabled);
            }
        }
    }
}
