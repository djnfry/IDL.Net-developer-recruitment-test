using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TechnicalTests;

namespace UnitTests
{
    [TestFixture]
    public class RaceConditionTests
    {
        /// <summary>
        /// This simulates a session store with a variable latency. In this instance the latency is causing a race condition in
        /// the RaceCondition class
        /// </summary>
        [TestCase(1000, 5)]
        public void CheckThatTheSessionManangerDoesEndInARaceCondition(int latency, int updateCount)
        {
            var sessions = new[] {
                new Session { Key = Guid.NewGuid().ToString() },
                new Session { Key = Guid.NewGuid().ToString() }
            };
            var sessionManager = Substitute.For<ISessionManager>();

            var testClass = new RaceCondition(sessionManager);
            var tasks = new List<Task>();
            sessionManager.Get(Arg.Any<string>())
                .Returns(info => new Session { Key = (string)info[0], Count = sessions.Single(s => s.Key == (string)info[0]).Count });
            sessionManager
                .When(x => x.Set(Arg.Any<ISession>()))
                .Do(info =>
                {
                    Thread.Sleep(latency);
                    sessions.Single(t => t.Key == ((ISession) info[0]).Key).Count = ((ISession) info[0]).Count;
                });

            foreach (var session in sessions)
            {
                for(int i = 0; i < updateCount; i++)
                {
                    tasks.Add(Task.Run(() => testClass.UpdateSession(session.Key)));
                }
            }

            Task.WaitAll(tasks.ToArray());
            Assert.IsTrue(sessions.All(s => s.Count == updateCount));
        }
    }
}
