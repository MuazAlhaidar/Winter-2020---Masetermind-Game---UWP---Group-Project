using Microsoft.Graphics.Canvas;
using Color = Windows.UI.Color;

namespace MasterMind_UWP_Edition {

    public class Peg {

        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; }
        public Color Color { get; set; }

        //---------------------------- Constructor -------------------------------

        public Peg() {


        }

        public Peg(int XCoordinate, int YCoordinate, int newRadius) {

            X = XCoordinate;
            Y = YCoordinate;
            Radius = newRadius;
        }

        //---------------------------- Click Check -------------------------------

        public bool IsClickWithinBounds(double XCoordinate, double YCoordinate) {

            return (XCoordinate < (X + Radius)) && (XCoordinate > (X - Radius)) &&
                (YCoordinate < (Y + Radius)) && (YCoordinate > (Y - Radius));
        }

        //---------------------------- Draw Elements -----------------------------

        public void Draw(CanvasDrawingSession drawingSession) {
            
            drawingSession.FillCircle(X, Y, Radius, Color);
        }
    }
}
