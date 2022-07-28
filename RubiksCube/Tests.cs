using System.Threading.Tasks;
using Xunit;

namespace RubiksCube
{
    public class Tests
    {
        [Fact]
        public async Task GivenSingleRotationOfFrontFace_ColoursChange()
        {
            // Arrange
            var rubik = new Rubik();

            // Act
            rubik.Rotate(FaceName.Front, Rotation.Clockwise);

            // Assert
            Assert.Equal(rubik.GetSquareColour(FaceName.Front, SquarePosition.BottomLeft), Colour.Green);
            Assert.Equal(rubik.GetSquareColour(FaceName.Right, SquarePosition.TopRight), Colour.Red);
            Assert.Equal(rubik.GetSquareColour(FaceName.Right, SquarePosition.MiddleLeft), Colour.White);

            // TODO: add more test for other squares on other faces 
        }

        [Fact]
        public async Task GivenNoRotations_ColoursInitialised()
        {
            // Arrange / Act
            var rubik = new Rubik();

            // Assert
            Assert.Equal(rubik.GetSquareColour(FaceName.Front, SquarePosition.BottomLeft), Colour.Green);
            Assert.Equal(rubik.GetSquareColour(FaceName.Right, SquarePosition.TopRight), Colour.Red);
            Assert.Equal(rubik.GetSquareColour(FaceName.Right, SquarePosition.MiddleLeft), Colour.Red);

            // TODO: add more test for other squares on other faces 
        }
    }
}
