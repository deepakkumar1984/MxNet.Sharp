using System;
using System.Collections.Generic;
using System.Text;
using ProfileHandle = System.IntPtr;

namespace MxNet
{
    public class Profiler
    {
        public class Task : IDisposable
        {
            private string _name;

            public Task(Domain domain, string name)
            {
                throw new NotImplementedException();
            }

            public void Start() => throw new NotImplementedException();

            public void Stop() => throw new NotImplementedException();

            public override string ToString()
            {
                return _name;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        public class Frame : IDisposable
        {
            private string _name;

            public Frame(Domain domain, string name)
            {
                throw new NotImplementedException();
            }

            public void Start() => throw new NotImplementedException();

            public void Stop() => throw new NotImplementedException();

            public override string ToString()
            {
                return _name;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        public class Event : IDisposable
        {
            private string _name;

            public Event(Domain domain, string name)
            {
                throw new NotImplementedException();
            }

            public void Start() => throw new NotImplementedException();

            public void Stop() => throw new NotImplementedException();

            public override string ToString()
            {
                return _name;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        public class Counter : IDisposable
        {
            private string _name;

            public Counter(Domain domain, string name, int? value = null)
            {
                throw new NotImplementedException();
            }

            public void SetValue(int value) => throw new NotImplementedException();

            public void Increment(int delta = 1) => throw new NotImplementedException();

            public void Decrement(int delta = 1) => throw new NotImplementedException();

            public override string ToString()
            {
                return _name;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public static Counter operator +(Counter c, int delta)
            {
                c.Increment(delta);
                return c;
            }

            public static Counter operator -(Counter c, int delta)
            {
                c.Decrement(delta);
                return c;
            }
        }

        public class Marker
        {
            private string _name;

            public Marker(Domain domain, string name)
            {
                throw new NotImplementedException();
            }

            public void Mark(string scope = "process") => throw new NotImplementedException();

            public override string ToString()
            {
                return _name;
            }
        }

        public class Domain
        {
            private string _name;

            private ProfileHandle handle;

            public Domain(string name)
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                return _name;
            }

            public Task NewTask(string name)
            {
                return new Task(this, name);
            }

            public Frame NewFrame(string name)
            {
                return new Frame(this, name);
            }

            public Counter NewCounter(string name)
            {
                return new Counter(this, name);
            }

            public Marker NewMarker(string name)
            {
                return new Marker(this, name);
            }
        }
    }
}
