namespace BuilderGenerator.UnitTests;

public class SinglePropertyTests
{
    [Fact]
    public void Test1()
    {
        var source = Generator.Generate(typeof(TestClass1));

        const string Expected = @"
using System;
using System.Collections.Generic;

namespace @namespace;
@usings

public class TestClass1Builder
{
    private int IntProperty;

    public TestClass1Builder SetIntProperty(int IntProperty)
    {
        this.IntProperty = IntProperty;
        return this;
    }
}";

        Assert.Equal(Expected, source);
    }

    private class TestClass1
    {
        public int IntProperty { get; set; }
    }
}