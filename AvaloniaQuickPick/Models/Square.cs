using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace AvaloniaQuickPick.Models
{
    public class Square
    {

        public Guid Id { get; set; }
        public Color Color { get; set; }
        public string ColorString => $"#{ValidateNumber(Color.R)}{ValidateNumber(Color.G)}{ValidateNumber(Color.B)}";

        private string ValidateNumber(int number)
        {
            var res = Convert.ToString(number, 16);

            if (String.IsNullOrEmpty(res))
                return null;

            if (res.Length == 1)
                res = $"0{res}";

            return res;
        }
        internal static Color GetRandomColor()
        {
            Random rnd = new Random();

            // Max is 200 to avoid white ones
            int red = rnd.Next(0, 200);
            int green = rnd.Next(0, 200);
            int blue = rnd.Next(0, 200);

            return Color.FromArgb(red, green, blue);
        }

        internal Square(Color color)
        {
            Id = Guid.NewGuid();
            this.Color = color;
        }
       
    }
}
