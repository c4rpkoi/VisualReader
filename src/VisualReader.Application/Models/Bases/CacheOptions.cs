﻿namespace VisualReader
{
    public class CacheOptions
    {
        public string Host { get; set; }
        public string Password { get; set; }
        public bool Ssl { get; set; } = true;
        public bool AbortOnConnectFail { get; set; } = false;
        public int CacheDuration { get; set; } = int.MaxValue;
        public int Database { get; set; } = -1;
    }
}