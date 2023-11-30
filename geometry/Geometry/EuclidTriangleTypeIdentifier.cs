using Geometry.Enums;
using Geometry.Interfaces;

namespace Geometry;

public class EuclidTriangleTypeIdentifier : ITriangleTypeIdentifier
{
    private const double TOLERANCE = 10e-6;
    
    public TriangleType GetTriangleType(double firstSide, double secondSide, double thirdSide)
    {
        if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
        {
            throw new ArgumentException("Triangle side cannot be equal or less than zero");
        }

        if (Math.Abs(firstSide - secondSide) < TOLERANCE && Math.Abs(firstSide - thirdSide) < TOLERANCE)
        {
            return TriangleType.ACUTE;
        }
        double[] sides = { firstSide, secondSide, thirdSide };
        Array.Sort(sides);

        var firstSidePow = Math.Pow(sides[0], 2);
        var secondSidePow = Math.Pow(sides[1], 2);
        var thirdSidePow = Math.Pow(sides[2], 2);
        
        if (firstSidePow + secondSidePow > thirdSidePow)
        {
            return TriangleType.ACUTE;
        }

        if (Math.Abs(firstSidePow + secondSidePow - thirdSidePow) < TOLERANCE)
        {
            return TriangleType.RIGHT;
        }

        return TriangleType.OBTUSE;
    }
}