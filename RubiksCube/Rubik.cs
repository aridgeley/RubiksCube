using System;
using System.Collections.Generic;

namespace RubiksCube
{
    /// <summary>
    /// Contains a representation of rubik cube with state information about the colour of each of its faces
    /// as well as methods to rotate faces and output the current state
    /// </summary>
    public class Rubik
    {
        private Dictionary<FaceName, Face> _faces;

        public Rubik()
        {
            _faces = new Dictionary<FaceName, Face>();

            AddFace(FaceName.Up, Colour.White);
            AddFace(FaceName.Down, Colour.Yellow);
            AddFace(FaceName.Front, Colour.Green);
            AddFace(FaceName.Back, Colour.Blue);
            AddFace(FaceName.Right, Colour.Red);
            AddFace(FaceName.Left, Colour.Orange);
        }

        public Colour GetSquareColour(FaceName faceName, SquarePosition squarePosition)
        {
            return _faces[faceName].GetSquareColour(squarePosition);
        }

        public void Rotate(FaceName faceName, Rotation rotation)
        {
            switch (faceName)
            {
                case FaceName.Front:
                    if (rotation == Rotation.Clockwise)
                    {
                        // store original colours for right face
                        List<Colour> initialColours = new List<Colour>
                    {
                        _faces[FaceName.Right].GetSquareColour(SquarePosition.TopLeft),
                        _faces[FaceName.Right].GetSquareColour(SquarePosition.MiddleLeft),
                        _faces[FaceName.Right].GetSquareColour(SquarePosition.BottomLeft)
                    };

                        _faces[FaceName.Right].SetSquareColour(SquarePosition.TopLeft, _faces[FaceName.Up].GetSquareColour(SquarePosition.BottomRight));
                        _faces[FaceName.Right].SetSquareColour(SquarePosition.MiddleLeft, _faces[FaceName.Up].GetSquareColour(SquarePosition.BottomMiddle));
                        _faces[FaceName.Right].SetSquareColour(SquarePosition.BottomLeft, _faces[FaceName.Up].GetSquareColour(SquarePosition.BottomLeft));

                        _faces[FaceName.Up].SetSquareColour(SquarePosition.BottomLeft, _faces[FaceName.Left].GetSquareColour(SquarePosition.TopRight));
                        _faces[FaceName.Up].SetSquareColour(SquarePosition.BottomMiddle, _faces[FaceName.Left].GetSquareColour(SquarePosition.TopMiddle));
                        _faces[FaceName.Up].SetSquareColour(SquarePosition.BottomRight, _faces[FaceName.Left].GetSquareColour(SquarePosition.TopLeft));

                        _faces[FaceName.Left].SetSquareColour(SquarePosition.TopRight, _faces[FaceName.Down].GetSquareColour(SquarePosition.TopRight));
                        _faces[FaceName.Left].SetSquareColour(SquarePosition.TopMiddle, _faces[FaceName.Down].GetSquareColour(SquarePosition.TopMiddle));
                        _faces[FaceName.Left].SetSquareColour(SquarePosition.TopLeft, _faces[FaceName.Down].GetSquareColour(SquarePosition.TopLeft));

                        _faces[FaceName.Down].SetSquareColour(SquarePosition.TopRight, initialColours[0]);
                        _faces[FaceName.Down].SetSquareColour(SquarePosition.TopMiddle, initialColours[1]);
                        _faces[FaceName.Down].SetSquareColour(SquarePosition.TopLeft, initialColours[2]);

                        //TODO: currently assumes front face will not change as only this is being rotated, but extra mappings will need to be added as this face rotates

                    }
                    else
                    {
                        // perform the clockwise actions 3 times
                    }
                    break;

                case FaceName.Back:
                    if (rotation == Rotation.Clockwise)
                    {
                        // TODO: add colour mappings as per the front face
                    }
                    break;

                case FaceName.Left:
                    // TODO: add colour mappings as per the front face
                    break;

                case FaceName.Right:
                    // TODO: add colour mappings as per the front face
                    break;

                case FaceName.Up:
                    // TODO: add colour mappings as per the front face
                    break;

                case FaceName.Down:
                    // TODO: add colour mappings as per the front face
                    break;
            }
        }

        public void PrintValues()
        {
            foreach (var face in _faces)
            {
                Console.WriteLine("Face: " + face.Key);
                foreach (int i in Enum.GetValues(typeof(SquarePosition)))
                {
                    var colour = face.Value.GetSquareColour((SquarePosition)i);
                    Console.WriteLine((SquarePosition)i + ": " + colour);
                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        private void AddFace(FaceName faceName, Colour colour)
        {
            Face face = new Face { Name = faceName };
            SetColourForAllSquaresOnFace(face, colour);
            _faces.Add(faceName, face);
        }

        private void SetColourForAllSquaresOnFace(Face face, Colour colour)
        {
            foreach (int i in Enum.GetValues(typeof(SquarePosition)))
            {
                face.SetSquareColour((SquarePosition)i, colour);
            }
        }
    }
}
