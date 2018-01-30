using System;
using System.Windows;
using Framework.BaseClasses;
using Microsoft.Test.Input;
using TestStack.White.UIItems;
using TestStack.White.Utility;
using Mouse = TestStack.White.InputDevices.Mouse;
using SpecialKeys = TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys;

namespace Framework.Utils
{
    public static class InputActions
    {
        public static void DragAndDrop(UIItem dragItem, UIItem dropItem)
        {
            Mouse.Instance.Location = dragItem.Location;      
            Mouse.LeftDown();
            Retry.For(() => dropItem.IsFocussed, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(0.1));
            Mouse.Instance.Location = dropItem.ClickablePoint;
            Mouse.LeftUp();
        }

        public static void MouseRightClickAndWait(UIItem expectedElement, UIItem clickingElement = null)
        {
            if (clickingElement != null)
            {
                Mouse.Instance.Location = clickingElement.Location;
            }
            Microsoft.Test.Input.Mouse.Down(MouseButton.Right);
            Retry.For(() => expectedElement.Visible, TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(0.1));
            Microsoft.Test.Input.Mouse.Up(MouseButton.Right);
        }

        public static void MouseClick(Point point)
        {
            var coords = Convert(point);
            Mouse.Instance.Click(coords);
        }

        public static void PressSpecialKey(SpecialKeys key)
        {
            BaseWindow.Window.Keyboard.PressSpecialKey(key);
        }

        private static Point Convert(Point point)
        {
            var windowLocation = BaseWindow.Window.Location;
            return new Point(windowLocation.X + point.X, windowLocation.Y + point.Y);
        }
    }
}
