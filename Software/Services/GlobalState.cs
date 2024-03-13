using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Services
{
    internal class GlobalState
    {
        private bool _isAdmin = false;

        public bool IsAdmin { get { return _isAdmin; }
        
            set { _isAdmin = value; OnIsAdminChanged(); }
        
        }

        public event EventHandler IsAdminChanged;

        protected virtual void OnIsAdminChanged()
        {
            IsAdminChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
