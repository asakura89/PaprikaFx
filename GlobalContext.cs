using System;
using Emi;
using Reflx;
using Ria;

namespace Paprika {
    public static class GlobalContext {
        public static Emitter Emitter { get; set; }

        public static PipelineExecutor PipelineExecutor { get; set; }

        public static void Initialize() {
            DynamicLoadAssemblies();

            Emitter = new XmlConfigEmitterLoader().Load();
            PipelineExecutor = new XmlConfigPipelineLoader().Load();
        }

        static void DynamicLoadAssemblies() {
            AppDomain.CurrentDomain.AssemblyResolve += DefaultAssemblyResolver.Resolve;
            ReflectionExt.LoadAssemblies(AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}