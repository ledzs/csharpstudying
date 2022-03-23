using ChangeElements;
using System;
using Xunit;
using FluentAssertions;
using MultipleOfFour;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldCorrectlyChangeElements()
        {
            //arrange
            var array = new[] { 3, 5, 6, 4, 1 };
            var firstIndex = 2;
            var secondIndex = 3;

            //act
            var newArray = ArrayUtils.ChangeElementsInArray(array, firstIndex, secondIndex);

            //assert
            newArray.Should().BeEquivalentTo(new[] { 3, 5, 4, 6, 1 });
        }
        [Fact]
        public void ShouldMultipleInArray()
        {
            //arrange
            int n = 6;
            var array = new int[n];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, 100);
            }

            //act
            var newArray = ArrayUtils2.MultipleFour(array, n);

            //assert

        }
    }
}
