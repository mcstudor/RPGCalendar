namespace RPGCalendar.Tests.TestingUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Moq;
#nullable disable
    public class StubbedSession : ISession
    {
        public StubbedSession(Mock<IHttpContextAccessor> mockContextAccessor)
        {
            GetDictionary = new Dictionary<string, byte[]>();
            Keys = new List<string>();
            mockContextAccessor.SetupProperty(e => e.HttpContext,
                new Mock<HttpContext>()
                    .SetupProperty(x => x.Session, this)
                    .Object);
            IsAvailable = true;
            Id = "1";
        }
        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out byte[] value)
        {
            this.GetDictionary.TryGetValue(key, out value);
            return true;
        }

        public void Set(string key, byte[] value)
        {
            GetDictionary.Add(key, value);
            Keys = Keys.Concat(new List<string> {key});
        }

        public void Remove(string key)
        {
            GetDictionary.Remove(key);
            var newKeys = Keys.ToList();
            newKeys.Remove(key);
            Keys = newKeys;
        }

        public void Clear()
        {
            GetDictionary.Clear();
            Keys = new List<string>();
        }

        public bool IsAvailable { get; }
        public string Id { get; }
        public IEnumerable<string> Keys { get; set; }
        public Dictionary<string, byte[]> GetDictionary { get; }
    }
#nullable enable
}
