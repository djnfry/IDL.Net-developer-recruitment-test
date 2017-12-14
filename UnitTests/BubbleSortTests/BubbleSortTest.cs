using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using TechnicalTests;

namespace UnitTests.BubbleSortTests
{
    [TestFixture]
    public class BubbleSortTest
    {
        [Test]
        public void BubbleSort_With2Items_ShouldReturnListWith2Items()
        {

            // arrange
            var sort = new Sorter();
            var list = new List<int> { 2, 1 };
            var comparer = Comparer<int>.Default;

            // act
            var sut = sort.BubbleSort(list, comparer);

            // assert
            sut.Should().NotBeEmpty();
            sut.Should().HaveCount(2);
        }

        [Test]
        public void BubbleSort_With2Items_ShouldReturnOrderList()
        {

            // arrange
            var sort = new Sorter();
            var list = new List<int> { 2, 1 };
            var expected = new List<int> { 1, 2 };
            var comparer = Comparer<int>.Default;

            // act
            var sut = sort.BubbleSort(list, comparer);

            // assert
            sut.Should().Equal(expected);
        }

        [Test]
        public void BubbleSort_With5Items_ShouldReturnOrderList()
        {

            // arrange
            var sort = new Sorter();
            var list = new List<int> { 10, 56, 2, 0, 6 };
            var expected = new List<int> { 0, 2, 6, 10, 56 };
            var comparer = Comparer<int>.Default;

            // act
            var sut = sort.BubbleSort(list, comparer);

            // assert
            sut.Should().Equal(expected);
        }
    }
}
