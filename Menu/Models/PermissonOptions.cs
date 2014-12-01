using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Menu.Models
{
    public class PermissonOptions
    {
        static public Permission agregar(Permission permision)
        {
            try
            {
                MenuContext db = new MenuContext();
                db.Permissions.Add(permision);
                db.SaveChanges();
            }
            catch {
                permision.ItemID = 0;
            }
            return permision;
        }


        static public Boolean eliminar(int PermissionId)
        {
            try { 
                MenuContext db = new MenuContext();
                var permision = db.Permissions.Where(x => x.PermissionId == PermissionId).SingleOrDefault();
                db.Permissions.Remove(permision);
                return true;
            }
            catch {
                return false;
            }
        }

        static public Boolean actualizar(Permission permision)
        {
            try { 
                MenuContext db = new MenuContext();
                var old_permision = db.Permissions.Where(x => x.PermissionId == permision.PermissionId).SingleOrDefault();
                old_permision.crud = permision.crud;
                old_permision.ItemID = permision.ItemID;
                old_permision.rol_id = permision.rol_id;
                old_permision.visible = permision.visible;
                db.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }
    }
}