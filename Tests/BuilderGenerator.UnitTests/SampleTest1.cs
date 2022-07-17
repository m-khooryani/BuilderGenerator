namespace BuilderGenerator.UnitTests;

public class SampleTest1
{
    [Fact]
    public void Test1()
    {
        var source = Generator.Generate(typeof(TestClass1));

        const string Expected = @"
using System;
using System.Collections.Generic;

namespace @namespace;

public class TestClass1Builder
{
    private Int32 IntProperty;

    public TestClass1Builder()
    {
        IntProperty = null;
    }

    public TestClass1 Build()
    {
        return new TestClass1()
        {
            IntProperty = this.IntProperty
        };
    }

    public TestClass1Builder SetIntProperty(Int32 IntProperty)
    {
        this.IntProperty = IntProperty;
        return this;
    }
}
";

        Assert.Equal(Expected.TrimStart(), source);
    }

    private class TestClass1
    {
        public int IntProperty { get; set; }
    }
}