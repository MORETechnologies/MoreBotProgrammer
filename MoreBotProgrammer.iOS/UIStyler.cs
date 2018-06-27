using System;
using CoreGraphics;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public static class UIStyler
    {
        public static void Style(params UIButton[] buttons)
        {
            foreach (var button in buttons) {
                button.BackgroundColor = Colors.Primary;
                button.SetTitleColor(Colors.LightText, UIControlState.Normal);
                button.SetTitleColor(Colors.LightText.ColorWithAlpha(0.75f), UIControlState.Highlighted);
                button.SetTitleColor(Colors.LightText.ColorWithAlpha(0.5f), UIControlState.Disabled);
            }
        }

        public class ShadowBuilder
        {
            CGSize offset;
            float opacity;
            float radius;
            CGColor color;
            CGPath path;

            public ShadowBuilder()
            {
                offset = new CGSize(2, 2);
                opacity = 0.5f;
                radius = 3;
                color = UIColor.Black.CGColor;
            }

            public ShadowBuilder WithOffset(CGSize offset)
            {
                this.offset = offset;
                return this;
            }

            public ShadowBuilder WithOpacity(float opacity)
            {
                this.opacity = opacity;
                return this;
            }

            public ShadowBuilder WithRadius(float radius)
            {
                this.radius = radius;
                return this;
            }

            public ShadowBuilder WithColor(UIColor color)
            {
                this.color = color.CGColor;
                return this;
            }

            public ShadowBuilder WithPath(UIBezierPath path)
            {
                this.path = path.CGPath;
                return this;
            }

            public void Apply(params UIView[] views)
            {
                foreach (var view in views) {
                    view.Layer.ShadowOffset = offset;
                    view.Layer.ShadowRadius = radius;

                    if (color != null) {
                        view.Layer.ShadowColor = color;
                    }

                    view.Layer.ShadowOpacity = opacity;

                    if (path != null) {
                        view.Layer.ShadowPath = path;
                    }
                }
            }
        }
    }
}
