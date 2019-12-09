using System;

namespace WeChatGrasper
{
    public class ContentHandler : IContentHandler
    {
        public event EventHandler ParserHandler;
        public event EventHandler ImageHandler;
        public event EventHandler DatabaseSaveHandler;
        public event EventHandler FileSaveHandler;

        public void HandlerList(string listResult)
        {
            ImageHandler?.Invoke(this, new ContentHandlerEventArgs { Result = listResult.Substring(0, 105) });
        }
        public void HandlerDetail<T>(string id, T detailResult)
        {
            ImageHandler?.Invoke(this, new ContentHandlerEventArgs { Result = detailResult.GetType().ToString() });
        }
    }

}

