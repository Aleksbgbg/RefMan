﻿namespace RefMan.Controls
{
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Forms;

    using Xceed.Wpf.Toolkit.PropertyGrid;
    using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

    using Binding = System.Windows.Data.Binding;

    public partial class PathEditor : ITypeEditor
    {
        private static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value",
                                                                                               typeof(string),
                                                                                               typeof(PathEditor),
                                                                                               new FrameworkPropertyMetadata(string.Empty,
                                                                                                                             FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public PathEditor()
        {
            InitializeComponent();
        }

        public string Value
        {
            get => (string)GetValue(ValueProperty);

            set => SetValue(ValueProperty, value);
        }

        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            Binding binding = new Binding("Value")
            {
                Source = propertyItem,
                Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay
            };
            BindingOperations.SetBinding(this, ValueProperty, binding);

            return this;
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "Select a folder to serve as the root path folder."
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Value = folderBrowserDialog.SelectedPath;
            }
        }
    }
}