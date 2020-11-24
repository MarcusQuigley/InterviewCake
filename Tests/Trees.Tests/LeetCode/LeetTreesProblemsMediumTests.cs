using Trees.LeetCode;
using Xunit;
namespace Trees.Tests.LeetCode
{
    public class LeetTreesProblemsMediumTests : BaseTreeTests
    {
        LeetTreesProblemsMedium sut;

        public LeetTreesProblemsMediumTests()
        {
            sut = new LeetTreesProblemsMedium();
        }

        [Theory]
        [InlineData(new int[] { 1, -666, 2, -666, -666, -666, 3 }, new int[] { 3, 2, 1 })]
        [InlineData(new int[] { 1, 2 }, new int[] { 2, 1 })]
        [InlineData(new int[] { 4, 2, 9, 3, 5, -666, 7 }, new int[] { 3, 5, 2, 7, 9, 4 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, -666, 7, -666, -666, 6, -666, -666, -666, -666, 8 }, new int[] { 4, 6, 5, 2, 8, 7, 3, 1 })]
        public void Test_PostorderTraversal(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);

            var actual = sut.PostorderTraversal(root);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, -666, 2, -666, -666, -666, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 1, 2 }, new int[] { 1, 2 })]
        [InlineData(new int[] { 4, 2, 8, 1, 3, 6 }, new int[] { 4, 2, 1, 3, 8, 6 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, -666, 7, -666, -666, 6, -666, -666, -666, -666, 8 }, new int[] { 1, 2, 4, 5, 6, 3, 7, 8 })]
        public void Test_PreorderTraversal(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);

            var actual = sut.PreorderTraversal(root);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2 }, new int[] { 2, 1 })]
        [InlineData(new int[] { 4, 2, 8, 1, 3, 6 }, new int[] { 1, 3, 2, 6, 8, 4 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, -666, 7, -666, -666, 6, -666, -666, -666, -666, 8 }, new int[] { 4, 6, 5, 2, 8, 7, 3, 1 })]
        [InlineData(new int[] { 1, 4, 3, 2 }, new int[] { 2, 4, 3, 1 })]
        [InlineData(new int[] { 1, -666, 2, -666, -666, 3 }, new int[] { 3, 2, 1 })]
        [InlineData(new int[] { }, new int[] { })]
        public void Test_PostOrderTraversalIntuitive(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);

            var actual = sut.PostOrderTraversalIntuitive(root);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 4, 2, 5, 1, 3 }, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 2, 1, 3 }, new int[] { 1, 2, 3 })]
        public void Test_TreeToDoubleListIter(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);

            var actual = sut.TreeToDoubleListIter(root);
            Assert.Equal(expected[expected.Length - 1], actual.left.val); //wont work if values null
        }

        [Theory]
        [InlineData(new int[] { 4, 2, 5, 1, 3 }, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 2, 1, 3 }, new int[] { 1, 2, 3 })]
        public void Test_TreeToDoubleList(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);

            var actual = sut.TreeToDoubleList(root);
            Assert.Equal(expected[expected.Length - 1], actual.left.val); //wont work if values null
        }
    }
}
