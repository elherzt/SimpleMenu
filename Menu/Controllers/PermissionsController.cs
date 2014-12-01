using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Menu.Models;

namespace Menu.Controllers
{
    public class PermissionsController : Controller
    {

        public Permission Add(Permission permission)
        {
            return PermissonOptions.agregar(permission);
        }

        public Boolean Remove(int PermissionId)
        {
            return PermissonOptions.eliminar(PermissionId);
        }

        public Boolean Update(Permission permission)
        {
            return PermissonOptions.actualizar(permission);
        }

    }
}
