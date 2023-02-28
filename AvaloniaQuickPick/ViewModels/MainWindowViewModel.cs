using AvaloniaQuickPick.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AvaloniaQuickPick.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Initialize();
        }

        private const int DEFAULT_SQUARES_QUANTITY = 10;
        private ObservableCollection<Square> Squares { get; set; }

        private void Initialize()
        {
            Squares = new ObservableCollection<Square>();

            for (int i = 0; i < DEFAULT_SQUARES_QUANTITY; i++)
            {
                Squares.Add(new Square(Square.GetRandomColor()));
            }
        }

        private void AddSquare()
        {
            if (Squares == null)
                Squares = new ObservableCollection<Square>();

            Squares.Add(new Square(Square.GetRandomColor()));
        }

        private void RemoveSquare()
        {
            if (Squares == null || Squares.Count < 1)
                return;

            Squares.Remove(Squares.Last());
        }

        private void ChangeColor(Guid parameter)
        {
            var color = Square.GetRandomColor();
            var index = Squares.IndexOf(Squares.First(s => s.Id == (Guid)parameter));

           // To create a new instance is safer
           Squares[index] = new Square(color);
        }
    }
}
