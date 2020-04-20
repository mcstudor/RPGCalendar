namespace RPGCalendar.Tests.Core.Extensions
{
    using System;
    using System.Threading;
    using FluentAssertions;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using NUnit.Framework;
    using RPGCalendar.Core.Extensions;
    using TestingUtilities;

    public class SessionExtensionTests
    {
#nullable disable
        //Set during setup
        private Mock<IHttpContextAccessor> mockContextAccessor;
        private ISession session;
#nullable enable

        [SetUp]
        public void SetUp()
        {
            mockContextAccessor = new Mock<IHttpContextAccessor>();
            session = new StubbedSession(mockContextAccessor);
        }

        [Test]
        public void SetObject_ExistsInSession()
        {
            var expected = new TestObject();
            session.Set("Test", expected);
            var actual = session.Get<TestObject>("Test");
            actual.Should().BeEquivalentTo(expected);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SetBool_ExistsInSession(bool expected)
        {
            session.SetBool("TestBool", expected);
            var actual = session.GetBool("TestBool");
            actual.Should().NotBeNull().And.Be(expected);
        }

        [Test]
        public void SetGuid_ExistsInSession()
        {
            var expected = Guid.NewGuid();
            session.SetGuid("TestGuid", expected);
            var actual = session.GetGuid("TestGuid");
            actual.Should().NotBeNull().And.Be(expected);
        }

        [Test]
        public void GetObject_NotInSession_ReturnsNull()
        {
            var actual = session.Get<TestObject>("BadKey");
            actual.Should().BeNull();
        }

        [Test]
        public void GetBool_NotInSession_ReturnsNull()
        {
            var actual = session.GetBool("BadKey");
            actual.Should().BeNull();
        }

        [Test]
        public void GetGuid_NotInSession_ReturnsNull()
        {
            var actual = session.GetGuid("BadKey");
            actual.Should().BeNull();
        }


    private class TestObject
        {
            public string String1 { get; set; } = "String1";
            public string String2 { get; set; } = "String2";
            public int In1 { get; set; } = 1;
            public bool False { get; set; } = false;
            public string? NullString { get; set; } = null;
        }

    }
}
