namespace RefMan.Helpers
{
    using System.Windows.Controls;
    using System.Windows.Interactivity;

    internal class AutoScrollBehavior : Behavior<ScrollViewer>
    {
        private bool _isUserScrolling;

        protected override void OnAttached()
        {
            AssociatedObject.ScrollChanged += AssociatedObject_ScrollChanged;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.ScrollChanged -= AssociatedObject_ScrollChanged;
        }

        private void AssociatedObject_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange > 0.0 && !_isUserScrolling)
            {
                AssociatedObject.ScrollToEnd();
            }

            _isUserScrolling = AssociatedObject.VerticalOffset != AssociatedObject.ScrollableHeight;
        }
    }
}