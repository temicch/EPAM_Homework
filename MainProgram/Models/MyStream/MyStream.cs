using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyStream
{
    //public delegate void InterceptStreamHandler(MethodBase method, params object[] arguments);

    //public class MyStream : Stream
    //{
    //    private Stream _stream;
    //    private InterceptStreamHandler _callback;

    //    public MyStream(Stream s, InterceptStreamHandler callback)
    //    {
    //        if (s == null) throw new ArgumentNullException("s");
    //        if (callback == null) throw new ArgumentNullException("callback");
    //        _stream = s;
    //        _callback = callback;
    //    }

    //    public override IAsyncResult BeginRead(byte[] buffer, int offset,
    //        int count, AsyncCallback callback, object state)
    //    {
    //        _callback(MethodBase.GetCurrentMethod(), buffer, offset,
    //            count, callback, state);
    //        return _stream.BeginRead(buffer, offset, count, callback, state);
    //    }

    //    public override IAsyncResult BeginWrite(byte[] buffer, int offset,
    //        int count, AsyncCallback callback, object state)
    //    {
    //        _callback(MethodBase.GetCurrentMethod(), buffer, offset,
    //            count, callback, state);
    //        return _stream.BeginWrite(buffer, offset, count,
    //            callback, state);
    //    }

    //    public override bool CanRead
    //    {
    //        get
    //        {
    //            _callback(MethodBase.GetCurrentMethod());
    //            return _stream.CanRead;
    //        }
    //    }

    //    public override string ToString()
    //    {
    //        _callback(MethodBase.GetCurrentMethod());
    //        return _stream.ToString();
    //    }

    //    public override void Write(byte[] buffer, int offset, int count)
    //    {
    //        _callback(MethodBase.GetCurrentMethod(), buffer, offset, count);
    //        _stream.Write(buffer, offset, count);
    //    }

    //    public override void WriteByte(byte value)
    //    {
    //        _callback(MethodBase.GetCurrentMethod(), value);
    //        _stream.WriteByte(value);
    //    }
    //}
}
