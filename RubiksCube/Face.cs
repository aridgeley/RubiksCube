using System.Collections.Generic;

namespace RubiksCube
{
    /// <summary>
    /// Contains state info about the colours of squares within a particular face, with methods to get and set this data
    /// </summary>
    public class Face
    {
        private FaceName _name;
        private Dictionary<SquarePosition, Colour> _squareColour;

        public Face()
        {
            _squareColour = new Dictionary<SquarePosition, Colour>();
        }

        public FaceName Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Colour GetSquareColour(SquarePosition position)
        {
            return _squareColour[position];
        }

        public void SetSquareColour(SquarePosition position, Colour colour)
        {
            _squareColour[position] = colour;
        }

    }
}
