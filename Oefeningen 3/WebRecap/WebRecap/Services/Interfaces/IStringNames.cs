namespace WebRecap.Services.Interfaces
{
    public interface IStringNames
    {
        void UpdateName(string objectName, string newName);
        List<string> GetAllNames();
        string DbContextName { get; set; }
        string DbContextname { get; set; }
        string RazorPageName { get; set; }
        string SolutionName { get; set; }
        string ModelName { get; set; }
        event Action OnChange;  
        void NotifyStateChanged(); 
    }
}
