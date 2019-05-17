namespace Refman.Controls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    [TemplatePart(Name = "PART_ExpansionToggle", Type = typeof(Button))]
    public class ExpandableTextBox : TextBox
    {
        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(nameof(IsExpanded),
                                                                                                   typeof(bool),
                                                                                                   typeof(ExpandableTextBox),
                                                                                                   new FrameworkPropertyMetadata(default(bool),
                                                                                                                                 IsExpandedPropertyChanged));

        public static readonly DependencyProperty CanToggleExpansionProperty = DependencyProperty.Register(nameof(CanToggleExpansion),
                                                                                                           typeof(bool),
                                                                                                           typeof(ExpandableTextBox),
                                                                                                           new FrameworkPropertyMetadata(true));

        public static readonly DependencyProperty CollapsedHeightProperty = DependencyProperty.Register(nameof(CollapsedHeight),
                                                                                                        typeof(double),
                                                                                                        typeof(ExpandableTextBox),
                                                                                                        new FrameworkPropertyMetadata(HeightProperty.DefaultMetadata.DefaultValue,
                                                                                                                                      CollapsedHeightPropertyChanged));

        public static readonly DependencyProperty ExpandedHeightProperty = DependencyProperty.Register(nameof(ExpandedHeight),
                                                                                                       typeof(double),
                                                                                                       typeof(ExpandableTextBox),
                                                                                                       new FrameworkPropertyMetadata(CollapsedHeightProperty.DefaultMetadata.DefaultValue, 
                                                                                                                                     ExpandedHeightPropertyChanged));

        public static readonly DependencyProperty ToggleExpansionImageProperty = DependencyProperty.Register(nameof(ToggleExpansionImage),
                                                                                                             typeof(ImageSource),
                                                                                                             typeof(ExpandableTextBox));

        static ExpandableTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExpandableTextBox), new FrameworkPropertyMetadata(typeof(ExpandableTextBox)));
        }

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);

            set => SetValue(IsExpandedProperty, value);
        }

        public bool CanToggleExpansion
        {
            get => (bool)GetValue(CanToggleExpansionProperty);

            set => SetValue(CanToggleExpansionProperty, value);
        }

        public double CollapsedHeight
        {
            get => (double)GetValue(CollapsedHeightProperty);

            set => SetValue(CollapsedHeightProperty, value);
        }

        public double ExpandedHeight
        {
            get => (double)GetValue(ExpandedHeightProperty);

            set => SetValue(ExpandedHeightProperty, value);
        }

        public ImageSource ToggleExpansionImage
        {
            get => (ImageSource)GetValue(ToggleExpansionImageProperty);

            set => SetValue(ToggleExpansionImageProperty, value);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Button expansionToggle = (Button)GetTemplateChild("PART_ExpansionToggle");

            expansionToggle.Click += ToggleExpand_Click;
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            ComputeCanToggleExpansion();

            if (!IsExpanded && Text.Contains("\n"))
            {
                IsExpanded = true;
            }
        }

        private static void IsExpandedPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ExpandableTextBox textBox = (ExpandableTextBox)dependencyObject;

            textBox.ComputeCanToggleExpansion();

            if ((bool)e.NewValue)
            {
                textBox.Height = textBox.ExpandedHeight;
            }
            else
            {
                textBox.Height = textBox.CollapsedHeight;
            }
        }

        private static void CollapsedHeightPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ExpandableTextBox textBox = (ExpandableTextBox)dependencyObject;

            double newCollapsedHeight = (double)e.NewValue;

            textBox.MinHeight = newCollapsedHeight;

            if (!textBox.IsExpanded)
            {
                textBox.Height = newCollapsedHeight;
            }
        }

        private static void ExpandedHeightPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ExpandableTextBox textBox = (ExpandableTextBox)dependencyObject;

            double newExpandedHeight = (double)e.NewValue;

            textBox.MaxHeight = newExpandedHeight;

            if (textBox.IsExpanded)
            {
                textBox.Height = newExpandedHeight;
            }
        }

        private void ToggleExpand_Click(object sender, EventArgs e)
        {
            IsExpanded = !IsExpanded;
        }

        private void ComputeCanToggleExpansion()
        {
            CanToggleExpansion = !IsExpanded || (!Text.Contains("\n") && IsExpanded);
        }
    }
}