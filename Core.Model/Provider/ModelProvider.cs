using Core.Model.Interfaces;

namespace Core.Model.Provider
{
    /// Made as singleton just for the hell of ot, usually i use static class
    /// 
    public class ModelProvider
    {
        // Fields
        private static ModelProvider fInstance;
        
        // Initialization
        private ModelProvider()
        {
            
        }

        // Properties
        public static ModelProvider Instance
        {
            get { return fInstance ?? (fInstance = new ModelProvider()); }
        }

        public IProvider pPropvider { get; private set; }

        // Private Methods

        // Public Methods
        public void AssignProvider(IProvider inProvider)
        {
            // for now it will be like that, after it could be assign only once
            pPropvider = inProvider;
        }
    }
}