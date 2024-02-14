using System.Drawing;

namespace ds.test.impl
{
    public interface IPlugin
    {
        string PluginName { get; }
        string Version { get; }
        Image Image { get; }
        string Description { get; }
        int Run(int input1, int input2);
    }
    abstract class PluginBase : IPlugin
    {
        public abstract string PluginName { get; }
        public abstract string Version { get; }
        public abstract Image Image { get; }
        public abstract string Description { get; }
        public abstract int Run(int input1, int input2);
    }

    public static class Plugins
    {
        private static IPlugin[] _plugins = new IPlugin[]
        {
            new AdditionPlugin(),
            new MultiplicationPlugin()
        };
        /// <summary>
        /// Получение количества плагинов
        /// </summary>
        public static int PluginsCount => _plugins.Length;
        /// <summary>
        /// Получение массива наименований плагинов
        /// </summary>
        /// <returns>Массив string</returns>
        public static string[] GetPluginNames()
        {
            string[] pluginNames = new string[_plugins.Length];
            for (int i = 0; i < _plugins.Length; i++)
            {
                pluginNames[i] = _plugins[i].PluginName;
            }
            return pluginNames;
        }
        /// <summary>
        /// Получение объекта плагина из массива плагинов
        /// </summary>
        /// <param name="pluginName">Название плагина</param>
        /// <returns>Объект плагина</returns>
        public static IPlugin? GetPlugin(string pluginName)
        {
            foreach (var plugin in _plugins)
            {
                if (plugin.PluginName == pluginName)
                {
                    return plugin;
                }
            }
            return null;
        }
    }
    /// <summary>
    /// Умножение
    /// </summary>
    class AdditionPlugin : PluginBase
    {
        public override string PluginName => "Сумма";
        public override string Version => "1";
        public override Image Image => null;
        public override string Description => "Сумма двух чисел";

        public override int Run(int input1, int input2)
        {
            return input1 + input2;
        }
    }
    /// <summary>
    /// Сумма
    /// </summary>
    class MultiplicationPlugin : PluginBase
    {
        public override string PluginName => "Умножение";
        public override string Version => "1";
        public override Image Image => null;
        public override string Description => "Умножение двух чисел";

        public override int Run(int input1, int input2)
        {
            return input1 * input2;
        }
    }
}