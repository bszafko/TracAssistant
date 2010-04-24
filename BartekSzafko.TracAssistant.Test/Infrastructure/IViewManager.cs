using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BartekSzafko.TracAssistant.Test.Infrastructure
{
    public interface IViewManager
    {
        IView ActiveView { get; set; }
        void Show(Type type);
    }
}
