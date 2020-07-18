using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace STI.Test
{
    public static class TestExtension
    {
        public static string AsJson<T>(this T data) => JsonConvert.SerializeObject(data, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        });
    }
}
