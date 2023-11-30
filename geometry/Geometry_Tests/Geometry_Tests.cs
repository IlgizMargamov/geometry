using Geometry;
using Geometry.Enums;
using Geometry.Interfaces;

namespace Geometry_Tests;

public class Geometry_Tests
{
    private ITriangleTypeIdentifier _triangleTypeIdentifier;
    [SetUp]
    public void Setup()
    {
        _triangleTypeIdentifier = new EuclidTriangleTypeIdentifier();
    }

    [Test]
    public void TestInvalidInput()
    {
        Assert.Catch<ArgumentException>(Test_Zeros);
        Assert.Catch<ArgumentException>(Test_Negative);
    }

    [TestCase(10,10,10, TriangleType.ACUTE)]
    [TestCase(5,5,5, TriangleType.ACUTE)]
    [TestCase(1,5,5, TriangleType.ACUTE)]
    [TestCase(3,4,5, TriangleType.RIGHT)]
    [TestCase(12,13,5, TriangleType.RIGHT)]
    [TestCase(2,5,3, TriangleType.ACUTE)]
    [TestCase(4,23,56, TriangleType.OBTUSE)]
    [TestCase(5,23,56, TriangleType.OBTUSE)]
    [TestCase(66,1,55, TriangleType.ACUTE)]
    public void Test_TriangleType(double firstSide, double secondSide, double thirdSide, TriangleType expected)
    {
        var actual = _triangleTypeIdentifier.GetTriangleType(firstSide, secondSide, thirdSide);
        if (actual == expected)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    private void Test_Zeros()
    {
        _triangleTypeIdentifier.GetTriangleType(0,0,0);
    }

    private void Test_Negative()
    {
        _triangleTypeIdentifier.GetTriangleType(-1,2,20);
    }
}