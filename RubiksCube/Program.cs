using System;

namespace RubiksCube
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rubik = new Rubik();

            // Uncomment or comment lines to add or subtract rotations
            // TODO: potentially allow user to specific number of rotations, face and rotation direction

            rubik.Rotate(FaceName.Front, Rotation.Clockwise);
            //rubik.Rotate(FaceName.Front, Rotation.Clockwise);
            //rubik.Rotate(FaceName.Front, Rotation.Clockwise);
            //rubik.Rotate(FaceName.Front, Rotation.Clockwise);

            rubik.PrintValues();

            Console.ReadLine();

        }
    }
}
