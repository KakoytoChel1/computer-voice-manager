using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows.Input;

namespace Voice_Manager.ViewModels
{
    internal class TextBoxBehaviour : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.TargetUpdated += AssociatedObject_TargetUpdated;
        }

        private void AssociatedObject_TargetUpdated(object? sender, System.Windows.Data.DataTransferEventArgs e)
        {
            TextBox textMessageBox = sender as TextBox;

            textMessageBox.SelectionLength = 0;
            textMessageBox.Select(textMessageBox.Text.Length, 0);
            Keyboard.Focus(textMessageBox);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}
