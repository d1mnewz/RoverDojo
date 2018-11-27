using System;
using FluentAssertions;
using RoverDojo.Core.Data;
using Xunit;

namespace RoverDojo.Tests.Core.Data
{
    public class ValueObjectShould
    {
        public class V : ValueObject<V>
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public TimeSpan TimeSpan { get; set; }
        }

        [Fact]
        public void BeEqual()
        {
            var time = DateTime.UtcNow.TimeOfDay;
            var vo = new V
            {
                Name = "abc",
                Type = "cba",
                TimeSpan = time
            };
            var vo2 = new V
            {
                Name = "abc",
                Type = "cba",
                TimeSpan = time
            };
            vo.Should().Be(vo2);
        }

        [Fact]
        public void NotBeEqual()
        {
            var vo = new V
            {
                Name = "abc",
                Type = "cba",
                TimeSpan = DateTime.UtcNow.TimeOfDay
            };
            var vo2 = new V
            {
                Name = "abc",
                Type = "cba2",
                TimeSpan = DateTime.UtcNow.TimeOfDay
            };
            vo.Should().NotBe(null);
            vo.Should().NotBe(vo2);
        }
    }
}