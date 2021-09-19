using System;
using System.IO;
using Emi;
using Reflx;
using Ria;

namespace Paprika {
    public static class GlobalContext {
        public static Emitter Emitter { get; set; }

        public static PipelineExecutor PipelineExecutor { get; set; }

        public static void Initialize() {
            DynamicLoadAssemblies();

            String paprikaConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "paprika.config.xml");
            Emitter = new XmlConfigEmitterLoader(paprikaConfig).Load();
            PipelineExecutor = new XmlConfigPipelineLoader(paprikaConfig).Load();
        }

        static void DynamicLoadAssemblies() {
            AppDomain.CurrentDomain.AssemblyResolve += DefaultAssemblyResolver.Resolve;
            ReflectionExt.LoadAssemblies(AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}