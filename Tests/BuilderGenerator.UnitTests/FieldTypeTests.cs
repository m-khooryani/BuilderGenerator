namespace BuilderGenerator.UnitTests;

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
    public void PrimitiveArrayAndListCombination_success()
    {
        var fields = FieldsResolver.GetFields(typeof(TypeWithArrayAndListCombination));
        Assert.Equal("List<Int32>[]", fields[0].TypeName());
        Assert.Equal("List<Int32[]>", fields[1].TypeName());
        Assert.Equal("List<Int32[][][]>", fields[2].TypeName());
        Assert.Equal("List<Int32>[,]", fields[3].TypeName());
        Assert.Equal("List<Int32[][,,][]>", fields[4].TypeName());
    }

    [Fact]
    public void TypeWithDictionary_success()
    {
        var fields = FieldsResolver.GetFields(typeof(TypeWithDictionary));
        Assert.Equal("Dictionary<String, Int32>", fields[0].TypeName());
    }

    [Fact]
    public void TypeWithReadonlyList_success()
    {
        var fields = FieldsResolver.GetFields(typeof(TypeWithReadonlyList));
        Assert.Equal("List<Int32>", fields[0].TypeName());
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
        public List<int[][][]> JaggedArrayListProp { get; set; }
        public List<int>[,] ListTwoDArrayProp { get; set; }
        public List<int[][,,][]> JaggedTwoDMixedArrayListProp { get; set; }
    }

    private class TypeWithDictionary
    {
        public Dictionary<string, int> DictionaryProp { get; set; }
    }

    private class TypeWithReadonlyList
    {
        public IReadOnlyList<int> ListProp { get; set; }
    }
}
