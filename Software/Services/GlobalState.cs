using System;

namespace Software.Services
{
    internal class GlobalState
    {
        private static readonly GlobalState _instance = new GlobalState();
        private bool _isAdmin = true;

        public static GlobalState Instance
        {
            get { return _instance; }
        }

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                _isAdmin = value;
                OnIsAdminChanged();
            }
        }

        public event EventHandler IsAdminChanged;

        private GlobalState()
        {
            // Private constructor to prevent external instantiation
        }

        protected virtual void OnIsAdminChanged()
        {
            IsAdminChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

