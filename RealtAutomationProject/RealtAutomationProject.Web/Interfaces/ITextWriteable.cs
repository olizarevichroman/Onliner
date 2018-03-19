using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtAutomationProject.Web.Interfaces
{
    public interface ITextWriteable
    {
        void SetText(string text);
        void ClearText();
    }
}
