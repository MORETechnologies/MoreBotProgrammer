using UIKit;

namespace MoreBotProgrammer.iOS
{
    public static class Fonts
    {
        public static readonly UIFont MainFont = UIFont.FromName("OpenSans-Regular", 17);
        public static readonly UIFont MainFontBold = UIFont.FromName("OpenSans-Bold", 17);
        public static readonly UIFont MainFontLight = UIFont.FromName("OpenSans-Light", 17);

        public static void ApplyFont(UIFont font, params UILabel[] labels)
        {
            foreach (var label in labels) {
                label.Font = font.WithSize(label.Font.PointSize);
            }
        }

        public static void ApplyFont(UIFont font, params UITextField[] textFields)
        {
            foreach (var field in textFields) {
                field.Font = font.WithSize(field.Font.PointSize);
            }
        }
    }
}
