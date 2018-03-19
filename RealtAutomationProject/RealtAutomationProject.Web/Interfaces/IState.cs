using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtAutomationProject.Web.Interfaces
{
    public interface IState
    {
        bool IsDisplayed { get; }
        bool IsEnabled { get; }
    }
}
