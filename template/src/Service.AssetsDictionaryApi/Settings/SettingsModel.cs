using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.AssetsDictionaryApi.Settings
{
    public class SettingsModel
    {
        [YamlProperty("AssetsDictionaryApi.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("AssetsDictionaryApi.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("AssetsDictionaryApi.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }
    }
}
