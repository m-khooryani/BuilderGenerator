namespace BuilderGenerator.UnitTests;

public class IntegrationTests
{
    [Fact]
    public void Generate_single_property_success()
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

    [Fact]
    public void Generate_multiple_properties_success()
    {
        var source = Generator.Generate(typeof(TestClass2));

        const string Expected = @"
using System;
using System.Collections.Generic;

namespace @namespace;

public class TestClass2Builder
{
    private Int32 IntProperty;
    private String StringProperty;

    public TestClass2Builder()
    {
        IntProperty = null;
        StringProperty = null;
    }

    public TestClass2 Build()
    {
        return new TestClass2()
        {
            IntProperty = this.IntProperty,
            StringProperty = this.StringProperty
        };
    }

    public TestClass2Builder SetIntProperty(Int32 IntProperty)
    {
        this.IntProperty = IntProperty;
        return this;
    }

    public TestClass2Builder SetStringProperty(String StringProperty)
    {
        this.StringProperty = StringProperty;
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

    private class TestClass2
    {
        public int IntProperty { get; set; }
        public string StringProperty { get; set; }
    }
}