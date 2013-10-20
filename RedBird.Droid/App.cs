namespace RedBird.Droid
{
    public static class App
    {
         public static void Start()
         {
             var mProvider = new RobinDemo.Provider.RobinProvider();
             
             mProvider.InitializeUser(0);

             Core.Model.Provider.ModelProvider.Instance.AssignProvider(mProvider);
         }
    }
}