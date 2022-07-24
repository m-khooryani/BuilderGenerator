﻿namespace BuilderGenerator.UnitTests;

public class FieldTypeTests
{
    [Fact]
    public void PrimitiveArray_success()
    {
        var fields = FieldsResolver.GetFields(typeof(TypeWithPrimitiveArray));
        Assert.Equal("Int32[]", fields[0].TypeName());
        Assert.Equal("Int32[,]", fields[1].TypeName());
        Assert.Equal("Int32[][]", fields[2].TypeName());
    }

    [Fact]
    public void PrimitiveList_success()
    {
        var fields = FieldsResolver.GetFields(typeof(TypeWithPrimitiveList));
        Assert.Equal("List<Int32>", fields[0].TypeName());
        Assert.Equal("List<Int32>", fields[1].TypeName());
    }

    [Fact]
    public void PrimitiveList_success1()
    {
        var fields = FieldsResolver.GetFields(typeof(TypeWithArrayAndListCombination));
        Assert.Equal("List<Int32>[]", fields[0].TypeName());
        Assert.Equal("List<Int32[]>", fields[1].TypeName());
    }

    private class TypeWithPrimitiveArray 
    {
        public int[] IntArrayProp { get; set; }
        public int[,] TwoDIntArrayProp { get; set; }
        public int[][] JaggedIntArrayProp { get; set; }
    }

    private class TypeWithPrimitiveList 
    {
        public List<int> IntListProp { get; set; }
        public IList<int> IntIListProp { get; set; }
    } 

    private class TypeWithArrayAndListCombination 
    {
        public List<int>[] ListArrayProp { get; set; }
        public List<int[]> ArrayListProp { get; set; }
    } 
}
