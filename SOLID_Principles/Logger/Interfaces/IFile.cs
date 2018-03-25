namespace Logger
{
    using System.Collections.Generic;

    public interface IFile
    {
        List<string> Messages { get; }
        ulong Size { get; }

        void AppendMessageToFile(string message);
    }
}