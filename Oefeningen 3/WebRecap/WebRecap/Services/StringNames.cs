using WebRecap.Services.Interfaces;

namespace WebRecap.Services
{
    public class StringNames : IStringNames
    {
        private string _dbContextName = "ApplicationDbContext";
        private string _dbContextname = "applicationDbContext";
        private string _razorPageName = "UserFundList";
        private string _solutionName = "WebRecap";
        private string _modelName = "UserFund";


        public string DbContextName
        {
            get => _dbContextName;
            set
            {
                if (_dbContextName != value)
                {
                    _dbContextName = value;
                    UpdateObjectNames();
                    NotifyStateChanged();  // Notify when a change occurs
                }
            }
        }
        public string DbContextname
        {
            get => _dbContextname;
            set
            {
                if (_dbContextname != value)
                {
                    _dbContextname = value;
                    UpdateObjectNames();
                    NotifyStateChanged();
                }
            }
        }
        public string RazorPageName
        {
            get => _razorPageName;
            set
            {
                if (_razorPageName != value)
                {
                    _razorPageName = value;
                    UpdateObjectNames();
                    NotifyStateChanged();
                }
            }
        }
        public string SolutionName
        {
            get => _solutionName;
            set
            {
                if (_solutionName != value)
                {
                    _solutionName = value;
                    UpdateObjectNames();
                    NotifyStateChanged(); 
                }
            }
        }
        public string ModelName
        {
            get => _modelName;
            set
            {
                if (_modelName != value)
                {
                    _modelName = value;
                    UpdateObjectNames();
                    NotifyStateChanged();
                }
            }
        }


        public event Action OnChange;  // Event to notify subscribers
        public void NotifyStateChanged() => OnChange?.Invoke();  // Method to invoke the event


        public string RazorPageNameHook => $"{RazorPageName}()";
        public string ModelNameS => $"{ModelName}s";

        private List<string> _objectNames = new List<string>();

        #region Initialized
        public StringNames()
        {
            UpdateObjectNames();
        }

        private void UpdateObjectNames()
        {
            _objectNames = new List<string>
            {
                DbContextName,
                DbContextname,
                RazorPageName,
                RazorPageNameHook,
                SolutionName,
                ModelName,
                ModelNameS
            };
        }
        #endregion


        public void UpdateName(string objectName, string newName)
        {
            if (objectName == "DbContextName")
            {
                DbContextName = newName;  
            }
            if (objectName == "DbContextname")
            {
                DbContextname = newName;
            }
            if (objectName == "RazorPageName")
            {
                RazorPageName = newName;
            }
            if (objectName == "SolutionName")
            {
                SolutionName = newName;
            }
            if (objectName == "ModelName")
            {
                ModelName = newName;
            }
        }

        public List<string> GetAllNames() => new List<string> { DbContextName, DbContextname, RazorPageName, RazorPageNameHook, SolutionName, ModelName, ModelNameS };
    }
}
