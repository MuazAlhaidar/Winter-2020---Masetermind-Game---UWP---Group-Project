using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Popups;

namespace MasterMind_UWP_Edition {

    public class Mastermind {

        public CanvasDrawingSession session;

        public int CurrentRow { get; set; }

        public List<Color> PegColors = new List<Color> { Colors.Red, Colors.Blue, Colors.Green, Colors.Yellow, Colors.Purple, Colors.Cyan };
        public List<Color> HintColors = new List<Color> { Colors.Green, Colors.Yellow, Colors.SlateGray };

        public List<List<Peg>> Pegs;
        public List<List<Peg>> HintPegs;
        public List<Peg> PegSecretCode;

        public int RightPlace { get; set; }
        public int RightColor { get; set; }

        public bool PlayerWon { get; set; }

        //---------------------------- Constructor -------------------------------

        public Mastermind() {

            CurrentRow = 0;

            PlayerWon = false;

            Pegs = new List<List<Peg>>();
            HintPegs = new List<List<Peg>>();

            int XCoordinate;
            int YCoordinate = 50;
            int newRadius = 20;

            for (int rowNumber = 0; rowNumber < 10; rowNumber++) {

                var row = new List<Peg>();

                XCoordinate = 50;

                for (int column = 0; column < 4; column++) {

                    var peg = new Peg() {

                        X = XCoordinate,
                        Y = YCoordinate,
                        Radius = newRadius,
                        Color = Colors.SlateGray
                    };

                    row.Add(peg);

                    XCoordinate += 60;
                }

                YCoordinate += 50;
                Pegs.Add(row);
            }

            PegSecretCode = new List<Peg>();

            XCoordinate = 50;
            YCoordinate = 620;

            Random random = new Random();

            for (int column = 0; column < 4; column++) {

                var peg = new Peg() {

                    X = XCoordinate,
                    Y = YCoordinate,
                    Radius = newRadius,
                    Color = PegColors[random.Next(PegColors.Count)]
                };

                PegSecretCode.Add(peg);

                XCoordinate += 60;
            }

            newRadius = 5;
            YCoordinate = 40;
            int newLine = 0;

            for (int rowNumber = 0; rowNumber < 10; rowNumber++) {

                var row = new List<Peg>();

                XCoordinate = 300;

                for (int column = 0; column < 4; column++) {

                    var peg = new Peg();

                    if (newLine >= 2) {

                        peg.X = XCoordinate - 40;
                        peg.Y = YCoordinate + 20;
                    }
                    else {

                        peg.X = XCoordinate;
                        peg.Y = YCoordinate;
                    }

                    peg.Radius = newRadius;
                    peg.Color = Colors.Black;

                    row.Add(peg);

                    XCoordinate += 20;

                    newLine++;
                }

                newLine = 0;

                YCoordinate += 50;
                HintPegs.Add(row);
            }
        }

        //---------------------------- Draw Elements -----------------------------

        public void DrawMastermind(CanvasDrawingSession drawingSession) {

            for (int rowIndex = 0; rowIndex < Pegs.Count; rowIndex++) {

                for (int columnIndex = 0; columnIndex < Pegs[rowIndex].Count; columnIndex++) {

                    Pegs[rowIndex][columnIndex].Draw(drawingSession);
                    HintPegs[rowIndex][columnIndex].Draw(drawingSession);
                }
            }

            for (int columnIndex = 0; columnIndex < PegSecretCode.Count; columnIndex++) {

                PegSecretCode[columnIndex].Draw(drawingSession);
            }
        }

        //---------------------------- Miscellaneous ------------------------------

        public Color NextColor(Color currentColor) {

            if (currentColor == Colors.SlateGray || currentColor == Colors.Cyan) {

                return PegColors[0];
            }
            else if (currentColor == Colors.Red) {

                return PegColors[1];
            }
            else if (currentColor == Colors.Blue) {

                return PegColors[2];
            }
            else if (currentColor == Colors.Green) {

                return PegColors[3];
            }
            else if (currentColor == Colors.Yellow) {

                return PegColors[4];
            }
            else if (currentColor == Colors.Purple) {

                return PegColors[5];
            }

            return default;
        }

        public bool IsCorrect() {

            /*
             Sources: majority of the algorithm was made by my teammate Zaki but i improved upon it using this page
             https://www.c-sharpcorner.com/article/mastermind-game-in-C-Sharp/
             what i got out of it was the use of the two arrays to keep track of RightPlace and RightColor placing
             int[] places = new int[] { -1, -1, -1, -1 };
             int[] places2 = new int[] { -1, -1, -1, -1 };
            */

            // Get the score of the player, and set that to Score Pegs
            RightPlace = 0;
            RightColor = 0;

            int[] places = new int[] { -1, -1, -1, -1 };
            int[] places2 = new int[] { -1, -1, -1, -1 };

            //Getting number of matching placement
            for (int i = 0; i < 4; i++) {

                if (PegSecretCode[i].Color == Pegs[CurrentRow - 1][i].Color) {

                    RightPlace++;

                    places[i] = 1;
                    places2[i] = 1;
                }
            }

            if (RightPlace == 4) {

                for (int i = 0; i < 4; i++) {

                    HintPegs[CurrentRow - 1][i].Color = HintColors[0];
                }

                CurrentRow = 10;

                PlayerWon = true;

                return true;
            }

            //Getting number of matching colors
            for (int i = 0; i < 4; i++) {

                for (int j = 0; j < 4; j++) {

                    if ((i != j) && (places[i] != 1) && (places2[j] != 1)) {

                        if (PegSecretCode[i].Color == Pegs[CurrentRow - 1][j].Color) {

                            RightColor++;
                            places[i] = 1;
                            places2[j] = 1;
                        }
                    }
                }
            }

            for (int i = 0; i < 4; i++) {

                if (RightPlace != 0) {

                    HintPegs[CurrentRow - 1][i].Color = HintColors[0];
                    RightPlace--;
                }
                else if (RightColor != 0) {

                    HintPegs[CurrentRow - 1][i].Color = HintColors[1];
                    RightColor--;
                }
                else {

                    HintPegs[CurrentRow - 1][i].Color = HintColors[2];
                }
            }

            PlayerWon = false;

            return false;
        }

        public async void PlayerWins() {

            MessageDialog dialog = new MessageDialog("Gratz, you may press Return and Start again");
            dialog.Commands.Add(new UICommand("Ok", null));
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;
            var cmd = await dialog.ShowAsync();
        }

        public async void PlayerLoses() {

            MessageDialog dialog = new MessageDialog("You Lost :(, you may press Return and Start again");
            dialog.Commands.Add(new UICommand("Ok", null));
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;
            var cmd = await dialog.ShowAsync();
        }
    }
}
