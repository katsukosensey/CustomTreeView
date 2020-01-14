using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IconButtonDesign
{
    public class IconButton : Button
    {
        public static readonly DependencyProperty NormalIconProperty;
        public static readonly DependencyProperty HighlightedIconProperty;
        public static readonly DependencyProperty PressedIconProperty;
        public static readonly DependencyProperty IconPaddingProperty;

        public static readonly DependencyProperty HighlightedBackgroundProperty;
        public static readonly DependencyProperty PressedBackgroundProperty;

        public static readonly DependencyProperty HighlightedForegroundProperty;
        public static readonly DependencyProperty PressedForegroundProperty;

        public static readonly DependencyProperty IconHeightProperty;
        public static readonly DependencyProperty IconWidthProperty;

        public static readonly DependencyProperty TextAlignmentProperty;
        public static readonly DependencyProperty TextWrappingProperty;
        public static readonly DependencyProperty TextPaddingProperty;

        public static readonly DependencyProperty HasUnderlineProperty;
        public static readonly DependencyProperty UnderlineSolidColorBrushProperty;
        public static readonly DependencyProperty UnderlineHeightProperty;
        public static readonly DependencyProperty UnderlineHighlightedSolidColorBrushProperty;
        public static readonly DependencyProperty UnderlinePressedSolidColorBrushProperty;
        public static readonly DependencyProperty UnderlineMarginProperty;

        static IconButton()
        {
            NormalIconProperty = DependencyProperty.Register(nameof(NormalIcon), typeof(ImageSource), typeof(IconButton));
            HighlightedIconProperty = DependencyProperty.Register(nameof(HighlightedIcon), typeof(ImageSource), typeof(IconButton));
            PressedIconProperty = DependencyProperty.Register(nameof(PressedIcon), typeof(ImageSource), typeof(IconButton));

            HighlightedBackgroundProperty = DependencyProperty.Register(nameof(HighlightedBackground), typeof(SolidColorBrush), typeof(IconButton));
            PressedBackgroundProperty = DependencyProperty.Register(nameof(PressedBackground), typeof(SolidColorBrush), typeof(IconButton));

            HighlightedForegroundProperty = DependencyProperty.Register(nameof(HighlightedForeground), typeof(SolidColorBrush), typeof(IconButton));
            PressedForegroundProperty = DependencyProperty.Register(nameof(PressedForeground), typeof(SolidColorBrush), typeof(IconButton));

            IconHeightProperty = DependencyProperty.Register(nameof(IconHeight), typeof(int), typeof(IconButton));
            IconWidthProperty = DependencyProperty.Register(nameof(IconWidth), typeof(int), typeof(IconButton));
            IconPaddingProperty = DependencyProperty.Register(nameof(IconPadding), typeof(Thickness), typeof(IconButton));

            TextAlignmentProperty = DependencyProperty.Register(nameof(TextAlignment), typeof(TextAlignment), typeof(IconButton));
            TextWrappingProperty = DependencyProperty.Register(nameof(TextWrapping), typeof(TextWrapping), typeof(IconButton));
            TextPaddingProperty = DependencyProperty.Register(nameof(TextPadding), typeof(Thickness), typeof(IconButton));

            HasUnderlineProperty = DependencyProperty.Register(nameof(HasUnderline), typeof(bool), typeof(IconButton));
            UnderlineSolidColorBrushProperty = DependencyProperty.Register(nameof(UnderlineSolidColorBrush), typeof(SolidColorBrush), typeof(IconButton));
            UnderlineHeightProperty = DependencyProperty.Register(nameof(UnderlineHeight), typeof(int), typeof(IconButton));
            UnderlineHighlightedSolidColorBrushProperty = DependencyProperty.Register(nameof(UnderlineHighlightedSolidColorBrush), typeof(SolidColorBrush), typeof(IconButton));
            UnderlinePressedSolidColorBrushProperty = DependencyProperty.Register(nameof(UnderlinePressedSolidColorBrush), typeof(SolidColorBrush), typeof(IconButton));
            UnderlineMarginProperty = DependencyProperty.Register(nameof(UnderlineMargin), typeof(Thickness), typeof(IconButton));
        }

        public ImageSource NormalIcon
        {
            get => (ImageSource)GetValue(NormalIconProperty);
            set => SetValue(NormalIconProperty, value);
        }
        public ImageSource HighlightedIcon
        {
            get => (ImageSource)GetValue(HighlightedIconProperty);
            set => SetValue(HighlightedIconProperty, value);
        }
        public ImageSource PressedIcon
        {
            get => (ImageSource)GetValue(PressedIconProperty);
            set => SetValue(PressedIconProperty, value);
        }
        public SolidColorBrush HighlightedBackground
        {
            get => (SolidColorBrush)GetValue(HighlightedBackgroundProperty);
            set => SetValue(HighlightedBackgroundProperty, value);
        }
        public SolidColorBrush PressedBackground
        {
            get => (SolidColorBrush)GetValue(PressedBackgroundProperty);
            set => SetValue(PressedBackgroundProperty, value);
        }
        public SolidColorBrush HighlightedForeground
        {
            get => (SolidColorBrush)GetValue(HighlightedForegroundProperty);
            set => SetValue(HighlightedForegroundProperty, value);
        }
        public SolidColorBrush PressedForeground
        {
            get => (SolidColorBrush)GetValue(PressedForegroundProperty);
            set => SetValue(PressedForegroundProperty, value);
        }
        public int IconHeight
        {
            get => (int)GetValue(IconHeightProperty);
            set => SetValue(IconHeightProperty, value);
        }
        public int IconWidth
        {
            get => (int)GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, value);
        }
        public Thickness IconPadding
        {
            get => (Thickness)GetValue(IconPaddingProperty);
            set => SetValue(IconPaddingProperty, value);
        }

        public TextAlignment TextAlignment
        {
            get => (TextAlignment)GetValue(TextAlignmentProperty);
            set => SetValue(TextAlignmentProperty, value);
        }
        public TextWrapping TextWrapping
        {
            get => (TextWrapping)GetValue(TextWrappingProperty);
            set => SetValue(TextWrappingProperty, value);
        }
        public Thickness TextPadding
        {
            get => (Thickness)GetValue(TextPaddingProperty);
            set => SetValue(TextPaddingProperty, value);
        }
        public bool HasUnderline
        {
            get => (bool)GetValue(HasUnderlineProperty);
            set => SetValue(HasUnderlineProperty, value);
        }
        public SolidColorBrush UnderlineSolidColorBrush
        {
            get => (SolidColorBrush)GetValue(UnderlineSolidColorBrushProperty);
            set => SetValue(UnderlineSolidColorBrushProperty, value);
        }
        public int UnderlineHeight
        {
            get => (int)GetValue(UnderlineHeightProperty);
            set => SetValue(UnderlineHeightProperty, value);
        }
        public SolidColorBrush UnderlineHighlightedSolidColorBrush
        {
            get => (SolidColorBrush)GetValue(UnderlineHighlightedSolidColorBrushProperty);
            set => SetValue(UnderlineHighlightedSolidColorBrushProperty, value);
        }
        public SolidColorBrush UnderlinePressedSolidColorBrush
        {
            get => (SolidColorBrush)GetValue(UnderlinePressedSolidColorBrushProperty);
            set => SetValue(UnderlinePressedSolidColorBrushProperty, value);
        }
        public Thickness UnderlineMargin
        {
            get => (Thickness)GetValue(UnderlineMarginProperty);
            set => SetValue(UnderlineMarginProperty, value);
        }
    }
}
