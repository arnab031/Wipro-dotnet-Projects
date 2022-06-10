using NUnit.Framework;

namespace NUnitTestProject01;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        //Arrange
        int ip = 5;
        int expected = 120;
        //Act
        int actual = Calculations.Factorial(ip);
        //Assert
        Assert.AreEqual(expected,actual);
    }
    [Test]
    public void Test2()
    {

        //Arrange
        int ip = 125;
        int expected = 521;
        //Act
        int actual = Calculations.Reverse(ip);
        //Assert
        Assert.AreEqual(expected, actual);
    }
}
