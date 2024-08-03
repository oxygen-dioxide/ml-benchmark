# ml-benchmark
Performance benchmark of loading json and yaml

In this benchmark, [a json file](MlBenchmark/data/dictionary.json) and [its equivalent yaml file](MlBenchmark/data/dictionary.yaml) are loaded with Newtonsoft.Json and YamlDotNet in C#, to compare the performance of loading them.

The C# class comes from [stakira/OpenUtau](https://github.com/stakira/OpenUtau/blob/master/OpenUtau.Core/Api/G2pDictionaryData.cs)

The yaml file comes from [Cadlaxa/Openutau-Yaml-Dictionaries](https://github.com/Cadlaxa/Openutau-Yaml-Dictionaries/blob/main/Dictionaries/EnunuX/Compiled%20Dictionary/english.enunux.yaml), and the json file is converted from it with python.