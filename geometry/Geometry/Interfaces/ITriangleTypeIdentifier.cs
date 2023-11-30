using Geometry.Enums;

namespace Geometry.Interfaces;

public interface ITriangleTypeIdentifier
{
    TriangleType GetTriangleType(double firstSide, double secondSide, double thirdSide);
}