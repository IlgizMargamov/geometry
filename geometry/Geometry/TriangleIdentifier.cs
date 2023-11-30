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

        if (Math.Pow(firstSide, 2) + Math.Pow(secondSide, 2) > Math.Pow(thirdSide, 2))
        {
            return TriangleType.ACUTE;
        }

        if (Math.Abs(Math.Pow(firstSide, 2) + Math.Pow(secondSide, 2) - Math.Pow(thirdSide, 2)) < TOLERANCE)
        {
            return TriangleType.RIGHT;
        }

        return TriangleType.OBTUSE;
    }
}