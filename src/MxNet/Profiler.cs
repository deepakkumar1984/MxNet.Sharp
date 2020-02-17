using System;
using System.Collections.Generic;
using System.Text;
using ProfileHandle = System.IntPtr;
using MxNet.Interop;

namespace MxNet
{
    public class Profiler
    {
        public static IntPtr profiler_kvstore_handle;

        public class Task : IDisposable
        {
            public string Name { get; set; }

            public Domain Domain { get; set; }

            internal ProfileHandle handle;

            public Task(Domain domain, string name)
            {
                Name = name;
                Domain = domain;
                NativeMethods.MXProfileCreateTask(domain.handle, name, out var @out);
                handle = @out;
            }

            public void Start()
            {
                if (handle != null)
                    NativeMethods.MXProfileDurationStart(handle);
            }

            public void Stop()
            {
                if (handle != null)
                    NativeMethods.MXProfileDurationStop(handle);
            }

            public override string ToString()
            {
                return Name;
            }

            public void Dispose()
            {
                if (handle != null)
                    NativeMethods.MXProfileDestroyHandle(handle);
            }
        }

        public class Frame : IDisposable
        {
            public string Name { get; set; }

            public Domain Domain { get; set; }

            internal ProfileHandle handle;

            public Frame(Domain domain, string name)
            {
                Domain = domain;
                Name = name;
                NativeMethods.MXProfileCreateFrame(domain.handle, name, out var @out);
                handle = @out;
            }

            public void Start()
            {
                if (handle != null)
                    NativeMethods.MXProfileDurationStart(handle);
            }

            public void Stop()
            {
                if (handle != null)
                    NativeMethods.MXProfileDurationStop(handle);
            }

            public override string ToString()
            {
                return Name;
            }

            public void Dispose()
            {
                if (handle != null)
                    NativeMethods.MXProfileDestroyHandle(handle);
            }
        }

        public class Event : IDisposable
        {
            public string Name { get; set; }

            internal ProfileHandle handle;

            public Event(string name)
            {
                Name = name;
                NativeMethods.MXProfileCreateEvent(name, out var @out);
                handle = @out;
            }

            public void Start()
            {
                if (handle != null)
                    NativeMethods.MXProfileDurationStart(handle);
            }

            public void Stop()
            {
                if (handle != null)
                    NativeMethods.MXProfileDurationStop(handle);
            }

            public override string ToString()
            {
                return Name;
            }

            public void Dispose()
            {
                if (handle != null)
                    NativeMethods.MXProfileDestroyHandle(handle);
            }
        }

        public class Counter : IDisposable
        {
            public string Name { get; set; }

            public Domain Domain { get; set; }

            internal ProfileHandle handle;

            public Counter(Domain domain, string name, int? value = null)
            {
                Domain = domain;
                Name = name;
                NativeMethods.MXProfileCreateCounter(domain.handle, name, out var @out);
                handle = @out;

                if (value.HasValue)
                    SetValue(value.Value);
            }

            public void SetValue(int value)
            {
                NativeMethods.MXProfileSetCounter(handle, value);
            }

            public void Increment(int delta = 1)
            {
                NativeMethods.MXProfileAdjustCounter(handle, delta);
            }

            public void Decrement(int delta = 1)
            {
                NativeMethods.MXProfileAdjustCounter(handle, -delta);
            }

            public override string ToString()
            {
                return Name;
            }

            public void Dispose()
            {
                if (handle != null)
                    NativeMethods.MXProfileDestroyHandle(handle);
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
            public string Name { get; set; }

            public Domain Domain { get; set; }

            public Marker(Domain domain, string name)
            {
                Domain = domain;
                Name = name;
            }

            public void Mark(string scope = "process")
            {
                NativeMethods.MXProfileSetMarker(Domain.handle, Name, scope);
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public class Domain
        {
            public string Name { get; set; }

            internal ProfileHandle handle;

            public Domain(string name)
            {
                Name = name;
                NativeMethods.MXProfileCreateDomain(name, out var @out);
                handle = @out;
            }

            public override string ToString()
            {
                return Name;
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
