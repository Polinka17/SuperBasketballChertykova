using ClassLibrary1;

namespace TestProject1;

public class Tests
{
    private Class1 _lib;
    [SetUp]
    public void Setup()
    {
        _lib = new Class1();
    }

    [Test]
    public void Test1()
    {
        //arrange
        double v = 1;
        double expected = 0.2;
        //act
        double actual = _lib.CalcT(v);
        //assert
        Assert.AreEqual(expected, actual);
    }
    [Test]
    public void Test2()
    {
        //arrange
        double v = 2.5;
        double expected = 0.51;
        //act
        double actual = _lib.CalcT(v);
        //assert
        Assert.AreEqual(expected, actual);
    }
}