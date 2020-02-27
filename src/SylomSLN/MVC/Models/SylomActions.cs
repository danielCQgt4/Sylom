using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC.Models {

    public interface SylomActions {

        ActionResult Create(string mode,object obj);

        ActionResult Read(string mode);

        ActionResult Read(string mode, object obj);

        ActionResult Update(string mode, object obj);

        ActionResult Delete(string mode, object obj);
    }
}
