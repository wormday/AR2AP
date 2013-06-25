namespace AR2AP.BLL
{
    using System;

    [Flags]
    public enum ClientTypeEnum : byte
    {
        直客 = 1,
        代理 = 2
    }
}