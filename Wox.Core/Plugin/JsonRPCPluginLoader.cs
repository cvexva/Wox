﻿using System.Collections.Generic;
using System.Linq;
using Wox.Plugin;

namespace Wox.Core.Plugin
{
    internal class JsonRPCPluginLoader<T> : IPluginLoader where T : JsonRPCPlugin, new()
    {
        public virtual IEnumerable<PluginPair> LoadPlugin(List<PluginMetadata> pluginMetadatas)
        {
            T jsonRPCPlugin = new T();
            List<PluginMetadata> jsonRPCPluginMetadatas = pluginMetadatas.Where(o => o.Language.ToUpper() == jsonRPCPlugin.SupportedLanguage.ToUpper()).ToList();

            return jsonRPCPluginMetadatas.Select(metadata => new PluginPair()
            {
                Plugin = jsonRPCPlugin, 
                Metadata = metadata
            }).ToList();
        }
    }
}
