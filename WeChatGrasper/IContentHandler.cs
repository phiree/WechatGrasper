using System;

namespace WeChatGrasper
{
    /// <summary>
    /// 内容处理
    ///   解析数据
    ///   分析是否有图片
    ///   构建其他url
    /// 
    /// </summary>
    public interface IContentHandler
    {
        event EventHandler ParserHandler;
        event EventHandler ImageHandler;
        event EventHandler DatabaseSaveHandler;
        event EventHandler FileSaveHandler;
        void HandlerList(string listResult);
        void HandlerDetail<T>(string id, T detailResult);

    }

}

