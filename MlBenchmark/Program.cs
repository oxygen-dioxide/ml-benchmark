using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace MlBenchmark{
    public class G2pDictionaryData {
        public struct SymbolData {
            public string symbol;
            public string type;
        }

        public struct Entry {
            public string grapheme;
            public string[] phonemes;
        }

        public SymbolData[] symbols;
        public Entry[] entries;
    }


    public class MlBenchmark {
        IDeserializer yamlDeserializer;
        public MlBenchmark(){
            yamlDeserializer = new DeserializerBuilder()
                .IgnoreUnmatchedProperties()
                .Build();
        }

        [Benchmark]
        public G2pDictionaryData LoadJsonDictionary() {
            var json = File.ReadAllText("data/dictionary.json");
            return JsonConvert.DeserializeObject<G2pDictionaryData>(json);
        }

        [Benchmark]
        public G2pDictionaryData LoadYamlDictionary() {
            var yaml = File.ReadAllText("data/dictionary.yaml");
            return yamlDeserializer.Deserialize<G2pDictionaryData>(yaml);
        }

        [Benchmark]
        public G2pDictionaryData LoadJsonDictionaryAsYaml() {
            var yaml = File.ReadAllText("data/dictionary.json");
            return yamlDeserializer.Deserialize<G2pDictionaryData>(yaml);
        }
    }

    public class Program{
        public static void Main(string[] args){
            var summary = BenchmarkRunner.Run<MlBenchmark>();
        }
    }
}
